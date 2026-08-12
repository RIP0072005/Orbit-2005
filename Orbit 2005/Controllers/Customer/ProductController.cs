using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Customer
{
    [Area("Customer")]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        public ProductController(ProductService _productService)
        {
            productService = _productService;
        }
        // shoping page, product details(user), planet products
        [Route("{search:alpha?}")]
        public IActionResult Index(string? search)
        {

            var products = productService.OrderedByNewest();
            ViewBag.sorted = "date";
            if(search == "low")
            {
                products = productService.OrderedByPrice();
                ViewBag.sorted = "low";
            }
            else if (search == "high")
            {
                products = productService.OrderedByPriceDesc();
                ViewBag.sorted = "high";
            }
            ViewBag.planets = productService.GetAllCategories();
            Random rand = new Random();
            // نسبة 12.5% إن العميل يلاقي موارد وهو بيقلب في الصفحة
            ViewBag.HasLoot = rand.Next(1, 101) <= 12.3;
            return View("~/Views/Customer/Product/Index.cshtml", products);
        }

        [Route("planets")]
        public IActionResult Category()
        {
            var planets = productService.GetPlanetsWithProducts();
            return View("~/Views/Customer/Category/Index.cshtml", planets);
        }

        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            var product = productService.GetByIdWithPlanet(id);
            if (product == null)
                return NotFound();

            Random rand = new Random();
            ViewBag.HasLoot = rand.Next(1, 101) <= 12.5;
            return View("~/Views/Customer/Product/Details.cshtml", product);
        }
    }
}
