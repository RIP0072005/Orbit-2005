namespace Orbit_2005.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Galaxy { get; set; }

        public string? Description {  get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
