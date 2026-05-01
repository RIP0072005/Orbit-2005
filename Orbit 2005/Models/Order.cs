namespace Orbit_2005.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Cosing { get; set; }
        public double? Discount { get; set; }

        public ICollection<ProductOrder>? ProductOrders { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
