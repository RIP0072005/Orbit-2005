using Microsoft.AspNetCore.Mvc;

namespace Orbit_2005.Controllers.Customer
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
