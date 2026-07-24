using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public ProductRepository(AppDbContext _context)
        {
            context = _context;
        }

        public void Add(Product product)
        {
            var Exist = context.Products.Any(p => p.Id == product.Id);
            if (!Exist)
                context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            var p = context.Products.FirstOrDefault(p => p.Id == product.Id);

            if (p != null)
            {
                context.Products.Remove(p);
            }            
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetByIdWithPlanet(int id)
        {
            return context.Products
                .Include(p => p.Planet)
                .FirstOrDefault(p => p.Id == id);
        }
        public bool IsNameExist(Product product)
        {
            return context.Products.Any(p => p.Name == product.Name && p.Id != product.Id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            var Exist = context.Products.Any(p => p.Id == product.Id);
            if (Exist)
                context.Update(product);
        }
    }
}
