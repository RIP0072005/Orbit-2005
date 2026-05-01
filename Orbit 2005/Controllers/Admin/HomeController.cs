using Microsoft.AspNetCore.Mvc;

namespace Orbit_2005.Controllers.Admin
{
    public class HomeController : Controller
    {
        [Route("/admin")]
        public IActionResult Index()
        {
            return View("~/Views/Admin/Home/Index.cshtml");
        }
    }
}
