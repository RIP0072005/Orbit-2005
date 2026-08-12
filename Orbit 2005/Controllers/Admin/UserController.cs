using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Models;
using Orbit_2005.Services;

namespace Orbit_2005.Controllers.Admin
{
    [Route("admin/user")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var users = userService.GetAll();
            return View("~/Views/Admin/User/Index.cshtml", users);
        }

        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            var user = userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/User/Details.cshtml", user);
        }

        [Route("create")]
        public IActionResult Create()
        {
            ViewBag.planets = userService.GetAllPlanets();
            return View("~/Views/Admin/User/Create.cshtml");
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Role = UserRole.Admin;
            var isExisting = userService.IsEmailExist(user);
            if (isExisting)
            {
                ModelState.AddModelError("Email", "User with this email already exists.");
            }
            if (ModelState.IsValid)
            {
                TempData["successMsg"] = "Admin Added Successfully";
                userService.Create(user);
                return RedirectToAction();
            }
            return View("~/Views/Admin/User/Create.cshtml", user);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var u = userService.GetById(id);
            if (u == null)
            {
                return NotFound();
            }

            ViewBag.planets = userService.GetAllPlanets();
            return View("~/Views/Admin/User/Update.cshtml", u);
        }

        [Route("update/{id}")]
        [HttpPost]
        public IActionResult Update(User user)
        {

            if (ModelState.IsValid)
            {
                userService.Update(user);
                TempData["updateSuccessMsg"] = "Data Updated Successfully";
                return RedirectToAction("index");
            }
            TempData["errorMsg"] = "Fill in required Fields";
            ViewBag.planets = userService.GetAllPlanets();
            return View("~/Views/Admin/User/Update.cshtml", user);
        }

        [Route("delete/{id:int}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            userService.Delete(user);
            return RedirectToAction("Index");
        }

        [HttpGet("IsNameExist")]
        public IActionResult IsEmailExist(User user)
        {
            Boolean isExisting = userService.IsEmailExist(user);
            if (isExisting)
            {
                return Json($"User with this email already exists.");
            }
            return Json(true);
        }

        [Route("addDummy")]
        public void AddDummyData()
        {
            userService.AddDummyUsers();
        }

        [Route("RemoveAll")]
        public void RemoveAll()
        {
            userService.DeleteAll();
        }

        

    }
}
