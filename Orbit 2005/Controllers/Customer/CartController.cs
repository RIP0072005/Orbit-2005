using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Customer
{
    [Area("Customer")]
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly CartService cartService;
        public CartController(CartService _cartService)
        {
            cartService = _cartService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var userId = GetUserId();
            if (userId == null)
            {
                TempData["error"] = "Please log in to view your cart.";
                return RedirectToAction("Login", "Account");
            }
            var cartItems = cartService.GetUserCart(userId.Value);

            ViewBag.TotalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity);
            return View("~/Views/Customer/Cart/Index.cshtml", cartItems);
        }

        [Route("AddToCart")]
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var userId = GetUserId();
            if (userId == null)
            {
                TempData["error"] = "Authentication required to access cart";
                return RedirectToAction("Login", "Account");
            }
            cartService.AddTocart(userId.Value, productId, quantity);
            TempData["successfulSign"] = "Item secured in your cargo successfully!";
            return RedirectToAction("Index", "Cart", new {Area = "Customer"});
        }

        [Route("RemoveFromCart")]
        [HttpPost]
        public IActionResult RemoveFromCart(int cartItemId) 
        {
            cartService.RemoveFromCart(cartItemId);
            TempData["successfulSign"] = "Item removed from your cargo successfully!";
            return RedirectToAction("Index", "Cart");
        }

        [Route("UpdateCart")]
        [HttpPost]
        public IActionResult UpdateQuantity(int cartItemId, int quantity)
        {
            cartService.UpdateCart(cartItemId, quantity);
            return RedirectToAction("Index", "Cart");
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
