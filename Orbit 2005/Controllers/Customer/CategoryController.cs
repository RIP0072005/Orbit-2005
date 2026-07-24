using Microsoft.AspNetCore.Mvc;

namespace Orbit_2005.Controllers.Customer
{
    public class CategoryController : Controller
    {
        [Route("planet")]
        public IActionResult Index()
        {
            return View("~/Views/Customer/Category/Index.cshtml");
        }

       
    }
}
