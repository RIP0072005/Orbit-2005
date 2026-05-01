namespace Orbit_2005.Models
{
    public class ProductOrder
    {
        public int orderId { get; set; }
        public int productId { get; set; }

        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
