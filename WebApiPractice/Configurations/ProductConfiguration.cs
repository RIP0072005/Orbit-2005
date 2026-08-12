using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiPractice.Models;

namespace WebApiPractice.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> P)
        {
            P.HasKey(p => p.Id);
            P.Property(p => p.Id).UseIdentityColumn(1, 1);
            P.Property(p => p.Title).IsRequired().HasMaxLength(30);
            P.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            P.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.categoryId);
            P.HasIndex(p => p.Title).IsUnique();
        }
    }
}
