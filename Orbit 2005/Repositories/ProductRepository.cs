using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Models.ViewModels;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext _context) : base(_context)
        {
        }
        public Product GetByIdWithPlanet(int id)
        {
            return context.Products
                .Include(p => p.Planet)
                .FirstOrDefault(p => p.Id == id);
        }



        public List<Product> GetTopProducts(int count = 0)
        {
            var query = context.Products
                .Include(p => p.Planet)
                .OrderByDescending(p => p.TotalSales)
                .ThenByDescending(p => p.Price);


            return count > 0 ? query.Take(count).ToList() : query.ToList();
        }


        private IQueryable<ProductPlanetViewModel> GetBaseProductQuery()
        {
            return context.Products
                .AsNoTracking() // عشان الأداء يكون طلقة
                .Select(p => new ProductPlanetViewModel
                {
                    ProductId = p.Id,
                    PlanetName = p.Planet.Name,
                    ProductName = p.Name, // صلحنا الغلطة
                    Price = p.Price
                });
        }

        public List<ProductPlanetViewModel> GetProductDetails(int count = 0)
        {
            var query = GetBaseProductQuery();
            return count > 0 ? query.Take(count).ToList() : query.ToList();
        }

        public List<ProductPlanetViewModel> GetProductPriceSortedASC(int count = 0)
        {
            var query = GetBaseProductQuery().OrderBy(p => p.Price);

            return count > 0 ? query.Take(count).ToList() : query.ToList();
        }

        public List<ProductPlanetViewModel> GetProductPriceSortedDESC(int count = 0)
        {
            var query =  GetBaseProductQuery().OrderByDescending(p => p.Price);

            return count > 0 ? query.Take(count).ToList() : query.ToList();
        }

        public List<ProductPlanetViewModel> GetProductDate(int count = 0)
        {
            var query = GetBaseProductQuery().OrderByDescending(p => p.ProductId);

            return count > 0 ? query.Take(count).ToList() : query.ToList();
        }

    }
}
