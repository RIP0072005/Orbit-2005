using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Filters;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Admin
{
    [AdminAuth]
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
            var IsAdmin = ValidAdmin();
            if (!IsAdmin)
                return NotFound();
            var stats = adminHomeService.GetStats();

            ViewBag.alerts = adminHomeService.GetSystemAlerts();
            ViewBag.orders = adminHomeService.GetOrders();

            return View("~/Views/Admin/Home/Index.cshtml", stats);
        }

        // helper functions

        private bool ValidAdmin()
        {
            var userRole = Request.Cookies["Role"];
            if (userRole == "Bofteek")
                return true;
            else
                return false;
        }

    }
}
