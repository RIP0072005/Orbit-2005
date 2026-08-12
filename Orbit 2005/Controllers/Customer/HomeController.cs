using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Models;
using Orbit_2005.Models.ViewModels;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Customer
{
    [Route("")]
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly UserService userService;

        public HomeController(UserService _userService)
        {
            userService = _userService;
        }

        [Route("")]
        public IActionResult Index()
        {
            ViewBag.TopProducts = userService.GetTopProducts();
            ViewBag.CategoryProducts = userService.GetCategoryProducts(3);
            return View("~/Views/Customer/Home/Index.cshtml");
        }

    }
}
