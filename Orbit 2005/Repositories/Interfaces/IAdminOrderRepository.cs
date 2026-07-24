using Orbit_2005.Models;

namespace Orbit_2005.Repositories.Interfaces
{
    public interface IAdminOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
    }
}
