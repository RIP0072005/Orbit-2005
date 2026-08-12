using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Models;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Customer
{
    [Area("Customer")]
    [Route("order")]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        public OrderController(OrderService _orderService)
        {
            orderService = _orderService;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Checkout()
        {
            var userid = GetUserId();
            if (userid == null)
            {
                TempData["error"] = "log in to access your orders";
                return RedirectToAction("Login", "Account", new {Area = "Customer"});
            }
            var orders = orderService.GetOrders(userid.Value);

            ViewBag.totalCost = orderService.TotalCost(userid.Value);
            if (ViewBag.totalCost == 0)
            {
                TempData["error"] = "Your cargo hold is empty!";
                return RedirectToAction("Index", "Cart", new { Area = "Customer" });
            }
                return View("~/Views/Customer/Order/Checkout.cshtml");  
        }

        [Route("")]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var userid = GetUserId();
            if (userid == null)
            {
                TempData["error"] = "log in to access your orders";
                return RedirectToAction("Login", "Account", new { Area = "Customer" });
            }
            try
            {
                orderService.PlaceOrder(userid.Value, order);
                TempData["successfulSign"] = "Order about to reach earth ;)";
                return View("~/Views/Customer/Order/OrderDone.cshtml", order);
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index", "Cart", new { Area = "Customer" });
            }
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult OrderDetails(int id)
        {
            var userid = GetUserId();
            if (userid == null)
            {
                TempData["error"] = "Login is required to access history";
                return RedirectToAction("Login", "Account", new { Area = "Customer" });
            }
            var order = orderService.GetOrderDetails(id);

            return View("~/Views/Customer/Order/Details.cshtml", order);
        }

        [Route("history")]
        public IActionResult History()
        {
            var userid = GetUserId();
            if (userid == null)
            {
                TempData["error"] = "Login is required to access history";
                return RedirectToAction("Login", "Account", new { Area = "Customer" });
            }
            var orders = orderService.GetOrders(userid.Value);
            return View("~/Views/Customer/Order/History.cshtml", orders);
        }

        // helper function 
        private int? GetUserId()
        {
            var userIdCookie = Request.Cookies["UserId"];
            if (!string.IsNullOrEmpty(userIdCookie) && int.TryParse(userIdCookie, out int userId))
            {
                return userId;
            }
            return null;
        }

    }
}
