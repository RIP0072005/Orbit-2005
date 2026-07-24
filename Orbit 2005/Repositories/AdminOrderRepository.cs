using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class AdminOrderRepository : IAdminOrderRepository
    {
        private readonly AppDbContext context;
        public AdminOrderRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return context.Orders.FirstOrDefault(o => o.Id == id);
        }


    }
}
