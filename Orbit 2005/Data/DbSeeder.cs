using Microsoft.EntityFrameworkCore;
using Orbit_2005.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orbit_2005.Data
{
    public static class DbSeeder
    {
        public static void SeedData(AppDbContext context) // غير AppDbContext لاسم الـ DbContext بتاعك
        {
            // 1. نتأكد إن الداتابيز مفهاش كواكب أصلاً عشان منكررش الداتا
            if (!context.Planets.Any())
            {
                var random = new Random();
                var planets = new List<Planet>();

                // قوائم الأسماء الفانتازية لتوليد الكواكب
                string[] planetPrefixes = { "Nova", "Kael", "Zeta", "Astro", "Nebulon", "Xeno", "Krystar", "Vortex", "Aethel", "Draco" };
                string[] planetSuffixes = { "Prime", "V", "Station", "Alpha", "Major", "Minor", "Nebula", "Core", "Abyss", "Haven" };
                string[] planetAdjectives = { "The Forgotten", "The Glowing", "Smuggler's", "Frozen", "Scorched", "Cybernetic", "Ancient", "Radiant" };

                // توليد 40 كوكب
                for (int i = 1; i <= 40; i++)
                {
                    string pName = i <= 10
                        ? $"{planetPrefixes[random.Next(planetPrefixes.Length)]} {planetSuffixes[random.Next(planetSuffixes.Length)]}"
                        : $"{planetAdjectives[random.Next(planetAdjectives.Length)]} {planetPrefixes[random.Next(planetPrefixes.Length)]}";

                    planets.Add(new Planet
                    {
                        Name = pName,
                        // لو عندك حقول تانية في الكوكب زي Description ضيفها هنا
                    });
                }

                context.Planets.AddRange(planets);
                context.SaveChanges(); // نحفظ الكواكب الأول عشان ناخد الـ IDs بتاعتها
            }

            // 2. نتأكد إن مفهاش منتجات، ونولد الـ 200 منتج
            // غيرنا الشرط عشان لو عندك منتجات قديمة يتجاهلها ويكمل لحد ما يوصل لـ 200
            if (context.Products.Count() < 200)
            {
                var random = new Random();
                var products = new List<Product>();
                var allPlanets = context.Planets.ToList();

                string[] productAdjectives = { "Quantum", "Plasma", "Dark Matter", "Titanium", "Hyper", "Sonic", "Cyber", "Nano", "Aether", "Galactic", "Void", "Magnetic" };
                string[] productNouns = { "Blaster", "Shield Core", "Reactor", "Thruster", "Armor Suit", "Crystal", "Energy Matrix", "Sensor Module", "Hyperdrive", "Scanner", "Plasma Rifle", "Exoskeleton" };

                string[] productDescriptions = {
        "A rare artifact recovered from the edge of the galaxy.",
        "Illegal in 4 systems, but highly effective.",
        "Standard issue for the Galactic Police, modified for extra power.",
        "Radiates a strange energy. Handle with care.",
        "Essential for long deep-space smuggling runs.",
        "Forged in the heart of a dying star."
    };

                for (int i = 1; i <= 200; i++)
                {
                    var randomPlanet = allPlanets[random.Next(allPlanets.Count)];

                    string prName = $"{productAdjectives[random.Next(productAdjectives.Length)]} {productNouns[random.Next(productNouns.Length)]} MK-{i}";
                    products.Add(new Product
                    {
                        Name = prName,
                        Description = productDescriptions[random.Next(productDescriptions.Length)],
                        Price = Math.Round((random.NextDouble() * 500) + 10, 2),
                        Amount = random.Next(0, 51),
                        planetId = randomPlanet.Id, 

                        // دلعنا المنتجات بتقييمات ومبيعات عشوائية عشان شكل الموقع يبقى جامد
                        Rate = Math.Round((random.NextDouble() * 2) + 3, 1), // تقييم من 3.0 لـ 5.0
                        NumOfRates = random.Next(5, 150), // عدد اللي قيموا
                        TotalSales = random.Next(10, 1000) // عدد المبيعات
                    });
                }

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}