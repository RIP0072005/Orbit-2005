using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext _context)
        {
            context = _context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public User GetByIDWithDetails(int id)
        {
            return context.Users
                .AsNoTracking()
                .Include(u => u.CartItems)
                .Include(u => u.Orders)
                .Include(u => u.Planet)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void DeleteAll()
        {
            for (int i = 0; i < context.Users.Count(); i++)
            {
                var user = context.Users.FirstOrDefault();
                if (user != null)
                {
                    context.Users.Remove(user);
                }
            context.SaveChanges();
            }
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('User', RESEED, 0)");
        }

        public User GetByIdWithOrders(int id)
        {
            return context.Users.Include(u => u.Orders).FirstOrDefault(u => u.Id == id);
        }
    }
}
