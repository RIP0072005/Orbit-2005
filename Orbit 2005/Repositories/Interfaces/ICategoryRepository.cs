using Orbit_2005.Models;
using Orbit_2005.Models.ViewModels;

namespace Orbit_2005.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Planet>
    {
        List<CategoryProductCountViewModel> GetCategoryProducts(int count);
        List<Planet> GetPlanetsWithTheirProducts();
    }
}
