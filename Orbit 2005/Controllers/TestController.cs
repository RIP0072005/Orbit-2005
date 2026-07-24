using Microsoft.AspNetCore.Mvc;

namespace Orbit_2005.Controllers
{
    public class TestController : Controller
    {
        #region Cookies
        //[Route("/test/{id}/{name}")]
        //public IActionResult Index(int id, string name)
        //{
        //    Response.Cookies.Append("id", id.ToString(), new CookieOptions() { Expires = DateTime.Now.AddHours(2) });
        //    return Content($"ID: {id}, Name: {name}");
        //}

        //[Route("/test/add")]
        //public IActionResult Add()
        //{
        //    {
        //        string id = Request.Cookies["id"] ?? "No ID cookie found";
        //        string name = Request.Cookies["name"] ?? "No Name cookie found";
        //        return Content($"Added product with ID: {id}, Name: {name}");
        //    }
        //} 
        #endregion

        [Route("/test/{id?}/{name?}")]
        public IActionResult Index(int id, string? name)
        {
            if (ModelState.IsValid)
            {
                return Content($"Index => ID: {id}, Name: {name}");
            }
            else
            {
                return Content("Invalid ID");
            }
        }
    }
}
