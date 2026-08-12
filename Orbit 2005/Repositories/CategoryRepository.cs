using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Models.ViewModels;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class CategoryRepository : GenericRepository<Planet>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext _context) : base(_context) 
        { } 

        public List<CategoryProductCountViewModel> GetCategoryProducts(int count = 0)
        {
            if (count > 0)
            {
                return context.Planets
                    .Select(c => new CategoryProductCountViewModel
                    {
                        CategoryId = c.Id,
                        CategoryName = c.Name,
                        ProductCount = c.Products.Count()
                    })
                    .OrderByDescending(c => c.ProductCount)
                    .Take(count)
                    .ToList();
            }

            else
                return context.Planets
                .Select(c => new CategoryProductCountViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    ProductCount = c.Products.Count()
                })
                .ToList();
        }

        public List<Planet> GetPlanetsWithTheirProducts()
        {
            return context.Planets.Include(p => p.Products).ToList();
        }
    }
}
