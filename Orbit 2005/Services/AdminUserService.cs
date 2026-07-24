using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class AdminUserService
    {
        private readonly IAdminUserRepository userRepository;

        public AdminUserService(IAdminUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public void Delete(User user)
        {
            userRepository.Delete(user);
            userRepository.Save();
        }
    }
}
