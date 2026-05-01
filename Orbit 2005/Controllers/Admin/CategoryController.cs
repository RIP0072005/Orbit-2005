using Microsoft.AspNetCore.Mvc;

namespace Orbit_2005.Controllers.Admin
{
    public class CategoryController : Controller
    {
        [Route("admin/category")]
        public IActionResult Index()
        {
            return View("~/Views/Admin/Category/Index.cshtml");
        }

        [Route("admin/category/create")]
        public IActionResult Create()
        {
            return View("~/Views/Admin/Category/Create.cshtml");
        }

        [Route("admin/category/update")]
        public IActionResult Update()
        {
            return View("~/Views/Admin/Category/Update.cshtml");
        }

        [Route("admin/category/delete")]
        public IActionResult Delete()
        {
            return View("~/Views/Admin/Category/Delete.cshtml");
        }

    }
}
