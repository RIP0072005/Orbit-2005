using WebApiPractice.Models;
using WebApiPractice.Repositories;

namespace WebApiPractice.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository categoryRepository;

        public CategoryService(CategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void Add(Category category)
        {
            categoryRepository.Add(category);
            categoryRepository.Save();
        }

        public bool Update(Category category)
        {
            if (!categoryRepository.IsExist(category.Id))
            {
                return false;
            }
            categoryRepository.Update(category);
            categoryRepository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            if (!categoryRepository.IsExist(id))
            {
                return false;
            }
            var category = categoryRepository.GetById(id);
            categoryRepository.Delete(category);
            categoryRepository.Save();
            return true;
        }

    }
}
