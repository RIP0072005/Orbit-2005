using Orbit_2005.Data;
using Orbit_2005.Models;

namespace Orbit_2005.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Planet> GetAll()
        {
            return context.Planets.ToList();
        }

        public Planet GetById(int id)
        {
            return context.Planets.Find(id);
        }

        public void Add(Planet planet)
        {
            context.Planets.Add(planet);
        }

        public void Update(Planet planet)
        {
            context.Planets.Update(planet);
        }

        public void Delete(Planet planet)
        {
            context.Planets.Remove(planet);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
