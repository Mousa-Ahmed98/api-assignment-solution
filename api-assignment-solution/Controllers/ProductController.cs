using api_assignment_solution.Models;
using api_assignment_solution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_assignment_solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{Id:int}")]
        public IActionResult Get(int Id)
        {
            Product? product = _productService.GetById(Id);
            if(product == null)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
            }
            else
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new {Id=product.Id}, product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            List<Product>? products = _productService.GetAll();
            if (products == null)
            {
                return BadRequest("No products");
            }
            return Ok(products);
        }

        [HttpPut]
        public IActionResult Update(Product product)//from request body
        {
            bool res = _productService.UpdateProduct(product);
            if (res)
            {
                return NoContent();
            }
            return BadRequest("Invalid Id");
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            bool res = _productService.DeleteProduct(Id);
            if (res)
            {
                return NoContent();
            }
            return BadRequest("Invalid Id");
        }
    }
}
