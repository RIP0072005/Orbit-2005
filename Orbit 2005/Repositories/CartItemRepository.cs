using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext _context) : base(_context)
        {}
        public void ClearCart(int userId)
        {
            var userCartItems = context.CartItems.Where(c => c.UserId == userId).ToList();
            context.CartItems.RemoveRange(userCartItems);
        }

        public CartItem GetCartItemByUserAndProduct(int userId, int productId)
        {
            return context.CartItems
                .FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);
        }

        public List<CartItem> GetCartItemsByUserId(int userId)
        {
            return context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToList();
        }
    }
}
