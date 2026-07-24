using Microsoft.AspNetCore.Mvc;

namespace Orbit_2005.Controllers.Customer
{
    public class FeaturesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("favourites")]
        public IActionResult Cart()
        {
            return View("~/Views/Customer/Features/Cart.cshtml");
        }
    }
}
