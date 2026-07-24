using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class AdminUserMemoryRepository : IAdminUserRepository
    {
        private List<User> users;

        public AdminUserMemoryRepository()
        {
            users = new List<User>()
            {
                new User() { Id = 1, Name = "RIP", Password = "123456" },
                new User() { Id = 2, Name = "Hoda", Password = "123456" },
                new User() { Id = 3, Name = "Sma", Password = "123456" },
                new User() { Id = 4, Name = "Ali", Password = "123456" },
            };
        }
        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(User user)
        {
            users.Remove(user);
        }

        public void Save()
        {
        }


    }
}
