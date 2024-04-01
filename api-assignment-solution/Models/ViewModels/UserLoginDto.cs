using System.ComponentModel.DataAnnotations;

namespace api_assignment_solution.Models.ViewModels
{
    public class LoginUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
