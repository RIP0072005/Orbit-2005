using Orbit_2005.Models;

namespace Orbit_2005.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByIdWithOrders(int id);
    }
}
