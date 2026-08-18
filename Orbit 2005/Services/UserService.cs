using Azure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orbit_2005.Models;
using Orbit_2005.Models.ViewModels;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;
        private readonly ICategoryRepository planetRepository;
        private readonly IProductRepository productRepository;

        public UserService(UserRepository _userRepository, ICategoryRepository _planetRepository, IProductRepository _productRepository)
        {
            userRepository = _userRepository;
            planetRepository = _planetRepository;
            productRepository = _productRepository;

        }


        // Read operations
        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public User GetByIdWithDetails(int id)
        {
            return userRepository.GetByIDWithDetails(id);
        }

        public User GetByEmail(string email)
        {
            return userRepository.GetAll().FirstOrDefault(u => u.Email == email);
        }

        public List<Product> GetTopProducts()
        {
            return productRepository.GetTopProducts(4);
        }

        public List<Planet> GetAllPlanets()
        {
            return planetRepository.GetAll();
        }


        public List<CategoryProductCountViewModel> GetCategoryProducts(int count = 0)
        {
            return planetRepository.GetCategoryProducts(count);
        }
        // Validation operations
        public bool IsEmailExist(User user)
        {
            return userRepository.GetAll().Any(u => u.Email == user.Email && u.Id != user.Id);
        }
        
        public bool ValidateUser(UserLoginViewModel userVM)
        {
            var user = userRepository.GetAll().FirstOrDefault(u => u.Email == userVM.Email && u.Password == userVM.Password);
            return user != null;
        }


        // Create, Update, Delete operations
        public void Delete(User user)
        {
            userRepository.Delete(user);
            userRepository.Save();
        }

        public void Create(User user)
        {
            userRepository.Add(user);
            userRepository.Save();
        }
        public void Update(User user)
        {
            userRepository.Update(user);
            userRepository.Save();
        }

        public void AddDummyUsers()
        {
            for (int i = 1; i <= 10; i++)
            {
                var user = new User
                {
                    Name = $"User {i}",
                    Email = $"user{i}@example.com",
                    Role = UserRole.Admin,
                    Password = "123456"
                };
               Create(user);
            }
        }

        public void DeleteAll()
        {
            userRepository.DeleteAll();
        }
    }
}
