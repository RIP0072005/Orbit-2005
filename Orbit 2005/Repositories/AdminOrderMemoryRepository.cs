using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class AdminOrderMemoryRepository : IAdminOrderRepository
    {
        private List<Order> orders;
        public AdminOrderMemoryRepository() 
        {
            orders = new List<Order>()
            {
                new Order { Id = 1, Name = "Order 1", Destination = "New Valley, Earth", Status = OrderStatus.pending, Costing = 1900},
                new Order { Id = 2, Name = "Order 2", Destination = "New Valley, Earth", Status = OrderStatus.delivered, Costing = 4500},
                new Order { Id = 3, Name = "Order 3", Destination = "New Valley, Earth", Status = OrderStatus.shiped, Costing = 600}
            };
        }

        public List<Order> GetAll()
        {
            return orders;
        }

        public Order GetById(int id)
        {
            return orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
