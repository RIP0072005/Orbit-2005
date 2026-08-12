using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class CartService
    {
        private readonly ICartItemRepository cartItemRepository;
        public CartService(ICartItemRepository _cartItemRepository)
        {
            cartItemRepository = _cartItemRepository;
        }

        public List<CartItem> GetUserCart(int userId)
        {
            return cartItemRepository.GetCartItemsByUserId(userId);
        }

        public void AddTocart(int userId, int productId, int quantity)
        {
            // check if the product already exists in the cart
            var existingCartItem = cartItemRepository.GetCartItemByUserAndProduct(userId, productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
                cartItemRepository.Update(existingCartItem);
            }
            else
            {
                // If the product doesn't exist, create a new cart item
                var newCartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                };
                cartItemRepository.Add(newCartItem);
            }
            cartItemRepository.Save();
        }

        public void RemoveFromCart(int cartItemId)
        {
            // Implementation for removing a product from the cart
            var cartItem = cartItemRepository.GetById(cartItemId);
            if (cartItem != null)
            {
                cartItemRepository.Delete(cartItem);
                cartItemRepository.Save();
            }
        }

        public void UpdateCart(int productId, int newQuantity)
        {
            // Implementation for updating the quantity of a product in the cart
            var cartItem = cartItemRepository.GetById(productId);
            if (cartItem != null)
            {
                if (newQuantity <= 0)
                {
                    // If the new quantity is zero or negative, remove the item from the cart
                    cartItemRepository.Delete(cartItem);
                }
                else
                {
                    // Update the quantity of the existing cart item
                    cartItem.Quantity = newQuantity;
                    cartItemRepository.Update(cartItem);
                }
                cartItemRepository.Save();
            }
        }

        public void ClearCart(int userId)
        {
            // Implementation for clearing the cart
            cartItemRepository.ClearCart(userId);
            cartItemRepository.Save();
        }
    }
}
