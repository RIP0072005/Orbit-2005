using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public bool IsExist(int id)
        {
            return context.Categories.Any(c => c.Id == id);
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
