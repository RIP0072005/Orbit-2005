namespace Orbit_2005.Models
{
    public enum OrderStatus
    {
        pending = 0,
        shiped = 1,
        delivered = 2,
        canceled = 3,
    }
    
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Costing { get; set; }
        public double? Discount { get; set; }

        public OrderStatus Status { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
