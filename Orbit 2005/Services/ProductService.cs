using Microsoft.AspNetCore.Mvc.Rendering;
using Orbit_2005.Models;
using Orbit_2005.Models.ViewModels;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        public ProductService(IProductRepository _productRepository, ICategoryRepository _categoryRepository)
        {
            productRepository = _productRepository;
            categoryRepository = _categoryRepository;
        }      

        public List<Product> GetAll()
        {
            return productRepository.GetAll();  
        }

        public SelectList GetAllCategories()
        {
            var categories = categoryRepository.GetAll();
            return new SelectList(categories, "Id", "Name");
        }
        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }
        public Product GetByIdWithPlanet(int id)
        {
            var product = productRepository.GetByIdWithPlanet(id);
            return product;
        }

        public List<ProductPlanetViewModel> GetProductDetails(int count = 0)
        {
            return productRepository.GetProductDetails(count);
        }

        public List<ProductPlanetViewModel> OrderedByPrice(int count = 0)
        {
            return productRepository.GetProductPriceSortedASC(count);
        }

        public List<ProductPlanetViewModel> OrderedByPriceDesc(int count = 0)
        {
            return productRepository.GetProductPriceSortedDESC(count);
        }

        public List<ProductPlanetViewModel> OrderedByNewest(int count = 0)
        {
            return productRepository.GetProductDate(count);
        }

        public List<Planet> GetPlanetsWithProducts()
        {
            return categoryRepository.GetPlanetsWithTheirProducts();
        }

        // crud operations
        public void Add(Product p)
        {
            try
            {
                productRepository.Add(p);
                productRepository.Save();
            }
            catch
            {
                productRepository.Add(p);
            }
        }

        public void Update(Product p)
        {
            try
            {
                productRepository.Update(p);
                productRepository.Save();
            }
            catch
            {
                productRepository.Update(p);
            }
        }

        public void Delete(Product p)
        {
            try
            {
                productRepository.Delete(p);
                productRepository.Save();
            }
            catch
            {
                productRepository.Delete(p);
            }
        }
        public bool IsNameExist(Product product)
        {
            return productRepository.GetAll().Any(p => p.Name == product.Name && p.Id != product.Id);
        }
    }
}