using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly AppDbContext context;

        public AdminUserRepository(AppDbContext _context)
        {
            context = _context;
        }
        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public void Delete(User user)
        {
            var Exist = context.Users.Any(u =>  u.Id == user.Id);
            if (Exist) 
                context.Users.Remove(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
