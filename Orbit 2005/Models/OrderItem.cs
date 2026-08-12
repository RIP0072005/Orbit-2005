using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Orbit_2005.Models
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; } 
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [ValidateNever]
        public Order? Order { get; set; }
        [ValidateNever]
        public Product? Product { get; set; }
    }
}
