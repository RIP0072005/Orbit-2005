using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Admin
{
    [Route("admin/user")]
    public class UserController : Controller
    {
        private readonly AdminUserService userService;

        public UserController(AdminUserService _userService)
        {
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
