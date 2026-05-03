using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orbit_2005.Models;

namespace Orbit_2005.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> P)
        {
            P.ToTable("Product");
            P.HasKey(p => p.Id);
            P.Property(p => p.Id)
                .UseIdentityColumn(10000, 1);

            P.HasOne(p => p.Planet)
                .WithMany(pl => pl.Products)
                .HasForeignKey(p => p.planetId)
                .OnDelete(DeleteBehavior.SetNull);

            P.Property(p => p.Amount)
                .HasDefaultValue(100);
        }
    }
}
