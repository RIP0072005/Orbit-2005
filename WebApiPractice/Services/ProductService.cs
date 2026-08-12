using WebApiPractice.Models;
using WebApiPractice.Repositories;

namespace WebApiPractice.Services
{
    public class ProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService(ProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public void Add(Product product)
        {
            productRepository.Add(product);
            productRepository.Save();
        }

        public bool Update(Product product)
        {
            if (!productRepository.IsExist(product.Id))
            {
                return false;
            }
            productRepository.Update(product);
            productRepository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            if (!productRepository.IsExist(id))
            {
                return false;
            }
            var product = productRepository.GetById(id);
            productRepository.Delete(product);
            productRepository.Save();
            return true;
        }

    }
}
