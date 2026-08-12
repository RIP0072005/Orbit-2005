using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orbit_2005.Models;

namespace Orbit_2005.Data.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> CI)
        {
            CI.ToTable("CartItems");
            CI.HasKey(c => c.Id);
            CI.Property(c => c.Id)
                .UseIdentityColumn(1000,1);
            CI.Property(c => c.UserId).IsRequired();
            CI.Property(c => c.ProductId).IsRequired();
            CI.Property(c => c.Quantity).IsRequired();
            CI.HasOne(c => c.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
