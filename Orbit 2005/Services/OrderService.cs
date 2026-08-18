using Orbit_2005.Models;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Services
{
    public class OrderService
    {
        private readonly ICartItemRepository cartItemRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        private readonly UserRepository userRepository;

        public OrderService(ICartItemRepository _cartItemRepository, IOrderRepository _orderRepository, IProductRepository _productRepository, UserRepository _userRepositorty)
        {
            cartItemRepository = _cartItemRepository;
            orderRepository = _orderRepository;
            productRepository = _productRepository;
            userRepository = _userRepositorty;
        }

        public void PlaceOrder(int userId, Order orderDetails)
        {
            var cartItems = cartItemRepository.GetCartItemsByUserId(userId);

            double totalPrice = 0;
            orderDetails.OrderItems = new List<OrderItem>();
            if (cartItems == null || cartItems.Count == 0)
            {
                throw new Exception("Your cart is empty commander");
            }
 
            foreach (var cartItem in cartItems)
            {
                if (cartItem.Quantity <= cartItem.Product.Amount)
                {
                    totalPrice += cartItem.Quantity * cartItem.Product.Price;
                }
                else
                {
                    continue;
                }
                    var orderItem = new OrderItem()
                    {
                        Price = cartItem.Product.Price,
                        Quantity = cartItem.Quantity,
                        ProductId = cartItem.ProductId,
                    };

                orderDetails.OrderItems.Add(orderItem);
                var p = productRepository.GetById(cartItem.ProductId);
                p.Amount -= orderItem.Quantity;
                productRepository.Update(p);
            }

            orderDetails.OrderDate = DateTime.UtcNow;
            orderDetails.UserId = userId;
            orderDetails.TotalPrice = totalPrice;
            if (orderDetails.OrderItems.Count == 0)
            {
                throw new Exception("All items in your cart are currently out of stock.");
            }

            var user = userRepository.GetById(userId);
            if (user.GalacticCredits < totalPrice)
            {
                throw new Exception("Insufficient Galactic Credits. Please recharge your wallet.");
            }

            // لو معاه رصيد، اخصم منه الفلوس
            user.GalacticCredits -= totalPrice;
            userRepository.Update(user);
            userRepository.Save();
            orderRepository.Add(orderDetails);
            orderRepository.Save();
            cartItemRepository.ClearCart(userId);
            cartItemRepository.Save();
            productRepository.Save();
        }
        public List<Order> GetOrders(int userId)
        {
            var user = userRepository.GetByIdWithOrders(userId);

            return user?.Orders?.ToList() ?? new List<Order>();

        }

        public double TotalCost(int userid)
        {
            var items = cartItemRepository.GetCartItemsByUserId(userid);
            double totalCost = items.Sum(i => i.Quantity * i.Product.Price);
            return totalCost;
        }

        public Order GetOrderDetails(int orderId)
        {
            return orderRepository.GetByIdWithDetails(orderId);
        }

        public User GetUserById(int id)
        {
            return userRepository.GetById(id);
        }
    }
    
}
