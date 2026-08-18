using Microsoft.EntityFrameworkCore;
using Orbit_2005.Models;

namespace Orbit_2005.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // استخدمنا الـ Standard Format وضفنا Encrypt=False
            // online Db
            optionsBuilder.UseSqlServer(@"Server=Orbit2005DB.mssql.somee.com;Database=Orbit2005DB;User Id=RIP_2005_SQLLogin_1;Password=v8xo6trbp1;TrustServerCertificate=True;Encrypt=False;");

            // Local Db
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Orbit_2005;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}