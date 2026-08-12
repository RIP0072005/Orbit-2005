using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;
using Orbit_2005.Models;

namespace Orbit_2005.Controllers.Admin
{
    [Route("admin/order")]
    public class OrderController : Controller
    {
        private readonly AppDbContext context;
        public OrderController()
        {
            context = new AppDbContext();
        }

        [Route("")]
        public IActionResult Index()
        {
            var orders = context.Orders.Include(o => o.User).ToList();
            return View("~/Views/Admin/Order/Index.cshtml", orders);
        }

        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            var order = context.Orders.Include(o => o.User).FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Order/Details.cshtml", order);
        }

        [Route("update")]
        [HttpGet]
        public IActionResult Update(int id) {
            var order = context.Orders.Include(o => o.User).FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Order/Update.cshtml", order);
        }

        [Route("update")]
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

        [Route("delete")]
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

        // helper function  
    }
}
