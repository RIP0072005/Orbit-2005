using Orbit_2005.Data;
using Orbit_2005.Models;
using Orbit_2005.Repositories.Interfaces;

namespace Orbit_2005.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext context;

        public GenericRepository()
        {
        }
        public GenericRepository(AppDbContext _context)
        {
            context = _context;
        }
        public virtual void Add(T entity)
        {
            var Exist = context.Set<T>().Any(e => e == entity);
            if (!Exist)
                context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            var Exist = context.Set<T>().Any(e => e == entity);
            if (Exist)
                context.Set<T>().Remove(entity);
        }

        public virtual List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            var Exist = context.Set<T>().Any(e => e == entity);
            if (Exist)
                context.Set<T>().Update(entity);
        }
    }
}
