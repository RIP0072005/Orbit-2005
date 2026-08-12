using Orbit_2005.Models;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class HomeService
    {
        private readonly UserRepository userRepository;
        private readonly IGenericRepository<Planet> planetRepository;
        public HomeService(UserRepository _userRepository, IGenericRepository<Planet> _planetRepository)
        {
            userRepository = _userRepository;
            planetRepository = _planetRepository;
        }




    }
}
