using FluentValidation;
using Orbit_2005.Models;

namespace Orbit_2005.Validators
{
    public class PlanetValidator : AbstractValidator<Planet>
    {
        public PlanetValidator() { 
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Enter Planet Name")
                .MinimumLength(3).WithMessage("Minimum length is 3 chars")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Accept Only Alpha and Spaces");

        }
    }
}
