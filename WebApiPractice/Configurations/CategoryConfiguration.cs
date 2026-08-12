using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiPractice.Models;

namespace WebApiPractice.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> C)
        {
            C.HasKey(c => c.Id);
            C.Property(c => c.Id).UseIdentityColumn(100,100);
            C.Property(c => c.Name).IsRequired().HasMaxLength(30);
            C.HasIndex(c => c.Name).IsUnique();
        }
    }
}
