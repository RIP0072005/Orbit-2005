using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        public string? Description { get; set; }
        public double TotalPrice { get; set; }
        public double? Discount { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; }
        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; }

        public int UserId { get; set; }

        [ValidateNever]
        public User User { get; set; }
    }
}
