using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Orbit_2005.Models
{
    public enum UserRole
    {
        Regular = 0,
        Admin = 1
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "please enter a valid Email Address")]
        [Remote(action: "IsEmailExist", controller: "User", AdditionalFields = "Id")]
        public string Email { get; set; }
        [MinLength(6, ErrorMessage = "Minimum Length for passowrd is 6 chars")]
        [MaxLength(20, ErrorMessage = "Maximum Length for password is 20 chars")]
        public string Password { get; set; }

        // balance
        public double GalacticCredits { get; set; } = 0;

        // resources
        public int Titanium { get; set; } = 0;
        public int PlasmaCores { get; set; } = 0;
        public int DarkMatter { get; set; } = 0;

        public UserRole Role { get; set; }
        [ValidateNever]
        public ICollection<CartItem>? CartItems { get; set; }
        [ValidateNever]
        public ICollection<Product>? Favourites { get; set; }
        public int? planetId { get; set; }
        public Planet? Planet { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
