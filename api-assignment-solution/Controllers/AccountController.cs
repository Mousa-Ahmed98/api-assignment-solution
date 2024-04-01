using api_assignment_solution.Models;
using api_assignment_solution.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_assignment_solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            ApplicationUser user = new ApplicationUser();
            if (ModelState.IsValid)
            {
                user.UserName = registerUser.UserName;
                user.Email = registerUser.Email;
                IdentityResult IdRes = await _userManager.CreateAsync(user, registerUser.Password);
                if (IdRes.Succeeded)
                {
                    return Ok("Created successfully");
                }
                return BadRequest(IdRes.Errors.First());
            }

            return BadRequest(ModelState);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(loginUser.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginUser.Password))
            {
                
                
                    //Claims
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    //If you want to make tokens unique per single user
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    
                    //Roles
                    List<string> roles = (List<string>) await _userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        foreach (string role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                    }

                    //secretKey
                    SymmetricSecurityKey authSecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("I am Mousa---ITI, hack it if you can"));
                    
                    //
                    SigningCredentials credentials =
                        new SigningCredentials(authSecretKey,SecurityAlgorithms.HmacSha256);
                    //Create token
                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer: "http://localhost:5052",
                        audience: "http://localhost:4200",
                        expires: DateTime.Now.AddHours(1),
                        claims: claims,
                        signingCredentials: credentials
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                
            }

            return BadRequest(ModelState);

        }
    }
}

    
