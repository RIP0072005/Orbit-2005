namespace Orbit_2005.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }

        public int? PlanetId { get; set; }
        public Planet? Planet { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
