using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Data;
using Orbit_2005.Filters;
using Orbit_2005.Models;
using Orbit_2005.Repositories;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Admin
{
    [AdminAuth]
    [Route("admin/planets")]
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var planets = categoryService.GetAll();
            return View("~/Views/Admin/Category/Index.cshtml", planets);
        }

        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            var p = categoryService.GetById(id);

            if (p == null)
                return NotFound();
            return View("~/Views/Admin/Category/Details.cshtml", p);
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View("~/Views/Admin/Category/Create.cshtml");
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Planet p, [FromServices] IValidator<Planet> validator)
        {
            ValidateData(p, validator);
            if (ModelState.IsValid)
            {
                categoryService.Add(p);
                TempData["successMsg"] = "Planet is Added Successfully";
                return RedirectToAction("Create");
            }
            return View("~/Views/Admin/Category/Create.cshtml", p);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var p = categoryService.GetById(id);
            if (p == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Category/Update.cshtml", p);
        }

        [Route("update/{id}")]
        [HttpPost]
        public IActionResult Update(Planet p, [FromServices] IValidator<Planet> validator)
        {
            ValidateData(p, validator);

            if (ModelState.IsValid)
            {
                categoryService.Update(p);
                return RedirectToAction("Index");
            }
            TempData["errorMsg"] = "Enter Valid Data";
            return View("~/Views/Admin/Category/Update.cshtml", p);
        }

        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var p = categoryService.GetById(id);
            if (p == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Category/Delete.cshtml", p);

        }

        [Route("delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Planet p)
        {
            categoryService.Delete(p);
            return RedirectToAction("Index");
        }

        // 
        private void ValidateData(Planet p, IValidator<Planet> validator)
        {
            var validationResult = validator.Validate(p);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState, "");
            }
        }



    }
}
