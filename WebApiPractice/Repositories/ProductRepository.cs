using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }

        public bool IsExist(int id)
        {
            return context.Products.Any(p => p.Id == id);
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
