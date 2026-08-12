using Orbit_2005.Models;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public List<Planet> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Planet GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void Add(Planet planet)
        {
            categoryRepository.Add(planet);
            categoryRepository.Save();
        }

        public void Update(Planet planet)
        {
            categoryRepository.Update(planet);
            categoryRepository.Save();
        }
        public void Delete(Planet planet)
        {
            categoryRepository.Delete(planet);
            categoryRepository.Save();
        }

        public List<Planet> GetPlanetsWithProducts()
        {
            return categoryRepository.GetPlanetsWithTheirProducts();
        }

    }
}
