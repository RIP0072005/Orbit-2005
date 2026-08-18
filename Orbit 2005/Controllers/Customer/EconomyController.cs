using Microsoft.AspNetCore.Mvc;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;
using System;

namespace Orbit_2005.Controllers.Customer
{
    [Area("Customer")]
    [Route("economy")]
    public class EconomyController : Controller
    {
        private readonly IUserRepository userRepository;

        public EconomyController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        // 1. استلام الموارد (لما العميل يدوس على الصندوق)
        [HttpPost("claim-loot")]
        public IActionResult ClaimLoot()
        {
            var userId = GetUserId();
            if (userId == null)
            {
                TempData["error"] = "U need to login to start collecting the loot ):";
                return RedirectToAction("Index", "Product", new { area = "Customer" });
            }

            var user = userRepository.GetById(userId.Value);

            Random rand = new Random();
            int luck = rand.Next(1, 101);

            int amount = 0;
            string resourceName = "";

            // تحديد المورد بناءً على نسبة الندرة
            if (luck <= 60) // 60% تيتانيوم
            {
                amount = rand.Next(5, 16);
                user.Titanium += amount;
                resourceName = "Titanium ☄️";
            }
            else if (luck <= 90) // 30% بلازما
            {
                amount = rand.Next(2, 7);
                user.PlasmaCores += amount;
                resourceName = "Plasma Cores ⚡";
            }
            else // 10% مادة مظلمة
            {
                amount = rand.Next(1, 3);
                user.DarkMatter += amount;
                resourceName = "Dark Matter 🌌 (LEGENDARY)";
            }

            userRepository.Update(user);
            userRepository.Save();

            TempData["successfulSign"] = $"Scrap recovered! You found {amount}x {resourceName}";

            // بيرجعه لنفس الصفحة اللي كان واقف فيها
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // 2. صفحة السوق السوداء (GET)
        [HttpGet("black-market")]
        public IActionResult BlackMarket()
        {
            var userId = GetUserId();
            if (userId == null) return RedirectToAction("Login", "Account", new { Area = "Customer" });

            var user = userRepository.GetById(userId.Value);
            return View("~/Views/Customer/Economy/BlackMarket.cshtml",user);
        }

        // 3. عملية التهريب (POST)
        [HttpPost("smuggle")]
        public IActionResult Smuggle(string resourceType, int amountToSmuggle)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var user = userRepository.GetById(userId.Value);

            double basePrice = 0;

            // تحديد السعر والتأكد من توفر الكمية مع العميل
            if (resourceType == "Titanium")
            {
                if (amountToSmuggle <= 0 || amountToSmuggle > user.Titanium) goto InvalidAmount;
                basePrice = 5.0;
                user.Titanium -= amountToSmuggle;
            }
            else if (resourceType == "PlasmaCores")
            {
                if (amountToSmuggle <= 0 || amountToSmuggle > user.PlasmaCores) goto InvalidAmount;
                basePrice = 25.0;
                user.PlasmaCores -= amountToSmuggle;
            }
            else if (resourceType == "DarkMatter")
            {
                if (amountToSmuggle <= 0 || amountToSmuggle > user.DarkMatter) goto InvalidAmount;
                basePrice = 100.0;
                user.DarkMatter -= amountToSmuggle;
            }
            else
            {
                goto InvalidAmount;
            }

            // نسبة النجاح في التهريب 65%، والمكسب 3 أضعاف
            Random rand = new Random();
            if (rand.Next(1, 101) <= 35)
            {
                double earned = amountToSmuggle * (basePrice * 3);
                user.GalacticCredits += earned;
                TempData["successfulSign"] = $"Mission Accomplished! You smuggled {resourceType} and made ${earned} Galactic Credits 💰";
            }
            else
            {
                TempData["error"] = $"BUSTED! The Galactic Police intercepted your ship. You lost all the smuggled {resourceType}! 🚨";
            }

            userRepository.Update(user);
            userRepository.Save();
            return RedirectToAction("BlackMarket");

        InvalidAmount:
            TempData["error"] = "Invalid resource type or amount.";
            return RedirectToAction("BlackMarket");
        }

        [HttpPost("sell-to-bank")]
        public IActionResult SellToBank(string resourceType, int amountToSell)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var user = userRepository.GetById(userId.Value);
            double basePrice = 0;

            // تحديد السعر العادي والتأكد من الكمية
            if (resourceType == "Titanium")
            {
                if (amountToSell <= 0 || amountToSell > user.Titanium) goto InvalidAmount;
                basePrice = 5.0;
                user.Titanium -= amountToSell;
            }
            else if (resourceType == "PlasmaCores")
            {
                if (amountToSell <= 0 || amountToSell > user.PlasmaCores) goto InvalidAmount;
                basePrice = 25.0;
                user.PlasmaCores -= amountToSell;
            }
            else if (resourceType == "DarkMatter")
            {
                if (amountToSell <= 0 || amountToSell > user.DarkMatter) goto InvalidAmount;
                basePrice = 100.0;
                user.DarkMatter -= amountToSell;
            }
            else
            {
                goto InvalidAmount;
            }

            // نسبة النجاح 100% (السعر الأساسي بدون مضاعفة)
            double earned = amountToSell * basePrice;
            user.GalacticCredits += earned;

            TempData["success"] = $"Official Trade Successful! You legally sold your {resourceType} for ${earned} Galactic Credits. 🏦";

            userRepository.Update(user);
            userRepository.Save();
            return RedirectToAction("BlackMarket");

        InvalidAmount:
            TempData["error"] = "Invalid resource type or amount.";
            return RedirectToAction("BlackMarket");
        }
        // helper function
        private int? GetUserId()
        {
            var userIdCookie = Request.Cookies["UserId"];
            if (!string.IsNullOrEmpty(userIdCookie) && int.TryParse(userIdCookie, out int userId)) return userId;
            return null;
        }
    }
}