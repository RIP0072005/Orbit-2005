using Orbit_2005.Models;
using Orbit_2005.Models.ViewModels;

namespace Orbit_2005.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetByIdWithPlanet(int id);
        List<Product> GetTopProducts(int count);
        List<ProductPlanetViewModel> GetProductDetails(int count);
        List<ProductPlanetViewModel> GetProductPriceSortedASC(int count);
        List<ProductPlanetViewModel> GetProductPriceSortedDESC(int count);
        List<ProductPlanetViewModel> GetProductDate(int count);
    }
}
