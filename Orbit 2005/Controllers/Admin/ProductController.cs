using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;
using Orbit_2005.Models;

namespace Orbit_2005.Controllers.Admin
{
    public class ProductController : Controller
    {
        private readonly AppDbContext context;

        public ProductController()
        {
            context = new AppDbContext();
        }
        [Route("admin/product")]
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View("~/Views/Admin/Product/Index.cshtml", products);
        }

        [Route("admin/product/{id}")]
        public IActionResult Details(int id)
        {
            var product = context.Products
                .Include(p => p.Planet)
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Product/Details.cshtml", product);
        }

        [Route("admin/product/create")]
        public IActionResult Create()
        {
            var Cats = context.Planets.ToList();
            return View("~/Views/Admin/Product/Create.cshtml", Cats);
        }

        [Route("admin/product/create")]
        [HttpPost]
        public IActionResult Create(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("admin/product/update/{id?}")]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            var product = context.Products.Include(p => p.Planet).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.planets = context.Planets.ToList();
            return View("~/Views/Admin/Product/Update.cshtml", product);
        }

        [Route("admin/product/update/{id}")]
        [HttpPost]
        public IActionResult Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        [Route("admin/product/delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var p = context.Products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Product/Delete.cshtml", p);

        }

        [Route("admin/product/delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
