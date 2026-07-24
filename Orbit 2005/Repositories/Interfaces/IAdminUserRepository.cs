using Orbit_2005.Models;

namespace Orbit_2005.Repositories.Interfaces
{
    public interface IAdminUserRepository
    {
        List<User> GetAll();

        User GetById(int id);

        void Delete(User user);

        void Save();

    }
}
