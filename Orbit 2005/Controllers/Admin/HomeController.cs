using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Admin
{
    public class HomeController : Controller
    {
        private readonly AdminHomeService adminHomeService;
        
        public HomeController (AdminHomeService _adminHomeService)
        {
            adminHomeService = _adminHomeService;
        }

        [Route("/admin")]
        public IActionResult Index()
        {
            var stats = adminHomeService.GetStats();

            ViewBag.alerts = adminHomeService.GetSystemAlerts();
            ViewBag.orders = adminHomeService.GetOrders();

            return View("~/Views/Admin/Home/Index.cshtml", stats);
        }


    }
}
