using Orbit_2005.Models;

namespace Orbit_2005.Repositories.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        List<CartItem> GetCartItemsByUserId(int userId);
        void ClearCart(int userId);
        CartItem GetCartItemByUserAndProduct(int userId, int productId);
    }
}
