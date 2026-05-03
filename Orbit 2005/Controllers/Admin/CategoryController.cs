using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Data;
using Orbit_2005.Models;

namespace Orbit_2005.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext context;

        public CategoryController()
        {
            context = new AppDbContext();
        }
        [Route("admin/planets")]
        public IActionResult Index()
        {
            var planets = context.Planets.ToList();
            return View("~/Views/Admin/Category/Index.cshtml", planets);
        }

        [Route("admin/planets/{id}")]
        public IActionResult Details(int id)
        {
            if (id == 0)
                return BadRequest();
            var p = context.Planets.FirstOrDefault(p => p.Id == id);

            if (p == null)
                return NotFound();
            return View("~/Views/Admin/Category/Details.cshtml", p);
        }

        [Route("admin/planet/create")]
        public IActionResult Create()
        {
            return View("~/Views/Admin/Category/Create.cshtml");
        }

        [Route("admin/planet/create")]
        [HttpPost]
        public IActionResult Create(Planet p)
        {
            context.Planets.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("admin/planet/update/{id?}")]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            var p = context.Planets.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Category/Update.cshtml", p);
        }

        [Route("admin/planet/update/{id}")]
        [HttpPost]
        public IActionResult Update(Planet p)
        {
            context.Planets.Update(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("admin/planet/delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var p = context.Planets.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Category/Delete.cshtml", p);

        }

        [Route("admin/planet/delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Planet p)
        {
            context.Planets.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
