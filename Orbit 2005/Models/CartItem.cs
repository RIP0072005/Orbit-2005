using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Orbit_2005.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [ValidateNever]
        public User User { get; set; }
        [ValidateNever]
        public Product Product { get; set; }
    }
}
