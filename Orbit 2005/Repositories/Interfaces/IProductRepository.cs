using Orbit_2005.Models;

namespace Orbit_2005.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        List<Product> GetAll();

        Product GetById(int id);
        Product GetByIdWithPlanet(int id);

        void Add(Product product);

        void Update(Product product);

        void Delete(Product product);
        bool IsNameExist(Product product);

        void Save();


    }
}
