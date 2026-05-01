namespace Orbit_2005.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public int Amount { get; set; }
        public int? planetId { get; set; }
        public Planet? Planet { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
