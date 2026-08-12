using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;
using WebApiPractice.Services;

namespace WebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;
        public CategoryController(CategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var category = categoryService.GetById(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }


        [HttpPost]
        public IActionResult Create(Category category)
        {
            categoryService.Add(category);
            return Created();
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            if (!categoryService.Update(category))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!categoryService.Delete(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
