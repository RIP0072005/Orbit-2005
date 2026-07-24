using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class ProductMemoryRepository : IProductRepository
    {
        private readonly List<Product> products;
        public ProductMemoryRepository()
        {
            products = new List<Product>() { 
                new Product() { Id = 1, Name = "Sample Product", Price = 0.0m, planetId = 1 },
                new Product() { Id = 2, Name = "Sample Product 2", Price = 10.0m, planetId = 2 },
                new Product() { Id = 3, Name = "Sample Product 3", Price = 20.0m, planetId = 3 }
            };
        }
        public List<Product> GetAll()
        {
            return products;
        }
        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetByIdWithPlanet(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Product product)
        {
            products.Add(product);
        }
        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.planetId = product.planetId;
            }
        }
        public void Delete(Product product)
        {
            products.Remove(product);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        // helper functions
        public bool IsNameExist(Product product)
        {
            return products.Any(p => p.Name == product.Name && p.Id != product.Id);
        }
    }
}
