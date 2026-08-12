using Orbit_2005.Models;

namespace Orbit_2005.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Order GetByIdWithDetails(int id);
    }
}
