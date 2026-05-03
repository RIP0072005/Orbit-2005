using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orbit_2005.Models;

namespace Orbit_2005.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> U)
        {
            U.ToTable("User");
            U.HasKey(u => u.Id);
            U.Property(u => u.Id)
                .UseIdentityColumn(100000, 1);
            U.Property(u => u.Name)
               .IsRequired()
               .HasColumnName("UserName")
               .HasMaxLength(25);


            U.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(20);
             U.Property(u => u.Email)
                .HasMaxLength(30);

            U.HasOne(u => u.Planet)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PlanetId)
                .OnDelete(DeleteBehavior.SetNull);

            U.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
