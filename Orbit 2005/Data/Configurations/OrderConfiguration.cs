using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orbit_2005.Models;

namespace Orbit_2005.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> O)
        {
            O.ToTable("Order");
            O.HasKey("Id");
            O.Property(o => o.Id)
                .UseIdentityColumn(1000000, 1);
        }
    }
}
