using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;
using Orbit_2005.Models;

namespace Orbit_2005.Controllers.Admin
{
    public class OrderController : Controller
    {
        private readonly AppDbContext context;
        public OrderController()
        {
            context = new AppDbContext();
        }

        [Route("/admin/order/")]
        public IActionResult Index()
        {
            var orders = context.Orders.Include(o => o.User).ToList();
            return View("~/Views/Admin/Order/Index.cshtml", orders);
        }

        [Route("/admin/order/{id}")]
        public IActionResult Details(int id)
        {
            var order = context.Orders.Include(o => o.User).FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Order/Details.cshtml", order);
        }

        [Route("/admin/order/update/{id}")]
        [HttpGet]
        public IActionResult Update(int id) {
            var order = context.Orders.Include(o => o.User).FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Order/Update.cshtml", order);
        }

        [Route("/admin/order/update/")]
        [HttpPost]
        public IActionResult Update(Order order)
        {
             if (order == null)
             {
                 return NotFound();
             }
            context.Orders.Update(order);
             context.SaveChanges();
             return RedirectToAction("Index");
        }

        [Route("/admin/order/delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            context.Orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
