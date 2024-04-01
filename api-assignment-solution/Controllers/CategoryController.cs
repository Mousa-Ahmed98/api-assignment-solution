using api_assignment_solution.Models;
using api_assignment_solution.Models.ViewModels;
using api_assignment_solution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_assignment_solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{Id:int}")]
        public IActionResult Get(int Id)
        {
            CategortResVM? categortResVM = _categoryService.GetById(Id);
            if (categortResVM == null)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(categortResVM);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddCategory(category);
            }
            else
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = category.Id }, category);
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            List<Category>? categories = _categoryService.GetAll();
            if (categories == null)
            {
                return BadRequest("No categories");
            }
            return Ok(categories);
        }

        /*[HttpPut]
        public IActionResult Update(Product product)//from request body
        {
            bool res = _categoryService.Updateca(product);
            if (res)
            {
                return NoContent();
            }
            return BadRequest("Invalid Id");
        }*/

        /*[HttpDelete]
        public IActionResult Delete(int Id)
        {
            bool res = _categoryService.DeleteProduct(Id);
            if (res)
            {
                return NoContent();
            }
            return BadRequest("Invalid Id");
        }*/
    }
}
