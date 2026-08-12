using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;
using WebApiPractice.Services;

namespace WebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var products = productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            
            productService.Add(product);
            return Created();
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            if (!productService.Update(product))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("test/{id:int}")]
        public IActionResult Test(int id)
        {
            return Ok($"Test endpoint called with id: {id}");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!productService.Delete(id))
            {
                return NotFound();
            } 
            return NoContent();
        }
    }
}
