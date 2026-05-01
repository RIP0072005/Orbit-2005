using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orbit_2005.Models;

namespace Orbit_2005.Data.Configurations
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> P)
        {
            P.ToTable("Planet");
            P.HasKey(p => p.Id);
            P.Property(p => p.Id)
                .UseIdentityColumn(100, 10);

            P.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

        }
    }
}
