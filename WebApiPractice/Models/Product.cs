using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApiPractice.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int categoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
    }
}
