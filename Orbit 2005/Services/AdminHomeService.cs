using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class AdminHomeService
    {
        private readonly AppDbContext context;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepo;
        public AdminHomeService(AppDbContext _context, IProductRepository _productRepository, IOrderRepository _orderRepo) 
        {
            context = _context;
            productRepository = _productRepository;
            orderRepo = _orderRepo;
        }

        public AdminStats GetStats()
        {
            AdminStats stats = new AdminStats();
            stats.TotalProducts = context.Products.Count();
            stats.TotalPlanets = context.Planets.Count();
            stats.TotalOrders = context.Orders.Count();
            stats.TotalRevenues = context.Orders.Sum(o => o.TotalPrice);
            return stats;
        }

        public List<Product> GetSystemAlerts()
        {
            return productRepository.GetAll().Where(p => p.Amount < 10).ToList();
        }

        public List<Order> GetOrders()
        {
            return orderRepo.GetAll();
        }
    }
}
