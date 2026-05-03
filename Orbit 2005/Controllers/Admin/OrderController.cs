using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;

namespace Orbit_2005.Controllers.Admin
{
    public class OrderController : Controller
    {
        private readonly AppDbContext context;
        OrderController()
        {
            context = new AppDbContext();
        }
        public IActionResult Index()
        {
            var orders = context.Orders.Include(o => o.User).ToList();
            return View("~/Views/Admin/Order/Index.cshtml", orders);
        }
    }
}
