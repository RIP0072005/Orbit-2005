using Orbit_2005.Data;

namespace Orbit_2005.Repositories
{
    public class CartRepository
    {
        private readonly AppDbContext context;
        public CartRepository(AppDbContext _context)
        {
           context = _context;
        }

        public void AddToCart(string productId, int quantity, int userId)
        {
            
        }
    }
}
