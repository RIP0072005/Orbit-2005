using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orbit_2005.Models;
using Orbit_2005.Models.ViewModels;
using Orbit_2005.Services;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Orbit_2005.Controllers.Customer
{
    [Area("Customer")]
    public class AccountController : Controller
    {
        private readonly UserService userService;
        public AccountController(UserService _userService)
        {
            this.userService = _userService;
        }

        // login , register, logout, profile details
        [Route("login")]
        public IActionResult Login()
        {
            return View("~/Views/Customer/Account/Login.cshtml");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLoginViewModel userVM)
        {
            var validLogin = userService.ValidateUser(userVM);
            if (!validLogin)
            {
                ModelState.AddModelError("Email", "Invalid Email or Password");
                return View("~/Views/Customer/Account/Login.cshtml", userVM);
            }

            var user = userService.GetByEmail(userVM.Email);

            var RoleValue = user.Role == UserRole.Regular ? "Regular" : "Bofteek";
            if (ModelState.IsValid)
            {
                Response.Cookies.Append("Role", RoleValue);
                Response.Cookies.Append("UserId", user.Id.ToString());
                TempData["successfulSign"] = $"Welcome Back {user.Name}";
                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }

            return View("~/Views/Customer/Account/Login.cshtml", userVM);

        }

        [Route("register")]
        public ActionResult Register()
        {
            ViewBag.Planets = new SelectList(userService.GetAllPlanets(), "Id", "Name");
            return View("~/Views/Customer/Account/Register.cshtml");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            if (userService.IsEmailExist(user))
            {
                ModelState.AddModelError("Email", "email account is already used");
            }
            if (ModelState.IsValid)
            {
                userService.Create(user);
                TempData["successfulSign"] = $"Welcome {user.Name} to our cosmic market";
                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }

            ViewBag.Planets = new SelectList(userService.GetAllPlanets(), "Id", "Name");
            return View("~/Views/Customer/Account/Register.cshtml", user);
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Role");
            Response.Cookies.Delete("UserId");

            TempData["successfulSign"] = $"Loged out Successfully";
            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }

        [Route("user/{id:int}")]
        public IActionResult Details(int id)
        {
            var user = userService.GetByIdWithDetails(id);
            if (user == null) 
                return NotFound();
            return View("~/Views/Customer/Account/Details.cshtml", user);
        }

    }
}
