using System.ComponentModel.DataAnnotations;

namespace Orbit_2005.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Minimum length is 6 chars")]
        public string Password { get; set; }
    }
}
