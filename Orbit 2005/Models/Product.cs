using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Orbit_2005.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Remote(action: "IsNameExist", controller: "Product", AdditionalFields = "Id")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public int Amount { get; set; }
        public int? planetId { get; set; }

        public Planet? Planet { get; set; }

        public ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
