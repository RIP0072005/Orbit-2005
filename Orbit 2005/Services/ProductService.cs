using Microsoft.AspNetCore.Mvc.Rendering;
using Orbit_2005.Models;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        private readonly CategoryRepository categoryRepository;
        public ProductService(IProductRepository _productRepository, CategoryRepository _categoryRepository)
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
            return productRepository.IsNameExist(product);
        }
    }
}