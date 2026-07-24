using Microsoft.AspNetCore.Mvc;

namespace Orbit_2005.Controllers.Customer
{
    [Route("")]
    [Area("Customer")]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View("~/Views/Customer/Home/Index.cshtml");
        }
    }
}
