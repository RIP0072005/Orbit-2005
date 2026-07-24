using FluentValidation;
using Orbit_2005.Models;

namespace Orbit_2005.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Enter Product Name")
                .MinimumLength(3).WithMessage("Minimum length is 3 chars")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Accept Only Alpha and Spaces");

            RuleFor(p => p.Price)
                .InclusiveBetween(1, 1_000_000).WithMessage("Price must be between 1 and 1,000,000");

            RuleFor(p => p.Amount)
                .InclusiveBetween(1, 10000).WithMessage("Amount must be between 1 and 10,000");
        }
    }
}