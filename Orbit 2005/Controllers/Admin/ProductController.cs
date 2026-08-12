using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orbit_2005.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Orbit_2005.Repositories;
using Orbit_2005.Services;
using Orbit_2005.Data;

namespace Orbit_2005.Controllers.Admin
{
    [Route("admin/product")]
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly AppDbContext context;

        public ProductController(ProductService _productService)
        {
            productService = _productService;
        }
        [Route("")]
        public IActionResult Index()
        {
            var products = productService.GetAll();
            return View("~/Views/Admin/Product/Index.cshtml", products);
        }

        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            var product = productService.GetByIdWithPlanet(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Product/Details.cshtml", product);
        }

        [Route("create")]
        public IActionResult Create()
        {
            var Cats = productService.GetAllCategories();
            ViewBag.planets = Cats;
            return View("~/Views/Admin/Product/Create.cshtml");
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Product p, [FromServices] IValidator<Product> validator)
        {
            // Validate the product data
            ValidateData(p, validator);

            Boolean isExisting = productService.IsNameExist(p);
            if (isExisting)
            {
                ModelState.AddModelError("Name", "Product with this name already exists.");
            }
            if (ModelState.IsValid)
            {
                // Save Product Data
                productService.Add(p);

                // Print the scuccessful massage
                TempData["successMsg"] = "Product is Added Successfully";
                return RedirectToAction("Create");
            }
            var Cats = productService.GetAllCategories();
            ViewBag.planets = Cats;
            return View("~/Views/Admin/Product/Create.cshtml", p);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var p = productService.GetById(id);
            if (p == null)
            {
                return NotFound();
            }

            ViewBag.planets = productService.GetAllCategories();
            return View("~/Views/Admin/Product/Update.cshtml", p);
        }

        [Route("update/{id}")]
        [HttpPost]
        public IActionResult Update(Product product, [FromServices] IValidator<Product> validator)
        {
            ValidateData(product, validator);
        

            if (ModelState.IsValid)
            {
                productService.Update(product);
                return RedirectToAction("index");
            }
            TempData["errorMsg"] = "Fill in required Fields";
            ViewBag.planets = productService.GetAllCategories();
            return View("~/Views/Admin/Product/Update.cshtml", product);
        }

        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var p = productService.GetById(id);
            if (p == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Product/Delete.cshtml", p);
            
        }

        [Route("delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            productService.Delete(product);
            return RedirectToAction("Index");
        }


        // Helper Functions
        [HttpGet("IsNameExist")]
        public IActionResult IsNameExist(Product product)
        {
            Boolean isExisting = productService.IsNameExist(product);
            if (isExisting)
            {
                return Json($"Product with this name already exists.");
            }
            return Json(true);

        }

        private void ValidateData(Product product, IValidator<Product> validator)
        {
            var validationResult = validator.Validate(product);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState, "");
            }
        }
    }
}
