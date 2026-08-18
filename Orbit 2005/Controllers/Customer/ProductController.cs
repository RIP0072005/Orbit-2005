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
        public IActionResult Index(string? search, int page = 1) 
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

            // ==========================================
            // بداية لوجيك الـ Pagination
            // ==========================================
            int pageSize = 12; // 12 منتج في الصفحة (عشان الـ Grid 3 عواميد فتبان متناسقة 4 صفوف)
            int totalItems = products.Count(); // إجمالي عدد المنتجات في الداتابيز
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize); // حساب عدد الصفحات

            // حماية بسيطة: لو اليوزر كتب رقم صفحة أقل من 1 أو أكبر من المتاح
            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

            // قص المنتجات (Skip and Take)
            var paginatedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // تمرير الأرقام للـ View عشان شريط الصفحات اللي تحت يشتغل
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalItems = totalItems;
            // ==========================================

            ViewBag.planets = productService.GetAllCategories();
            
            // لاحظ إننا بنبعت paginatedProducts دلوقتي مش products العادية
            return View("~/Views/Customer/Product/Index.cshtml", paginatedProducts); 
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
                ViewBag.HasLoot = rand.Next(1, 101) <= 15;
            return View("~/Views/Customer/Product/Details.cshtml", product);
        }

    }
}
