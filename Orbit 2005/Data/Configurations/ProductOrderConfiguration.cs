using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orbit_2005.Models;

namespace Orbit_2005.Data.Configurations
{
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> PO)
        {
            PO.ToTable("ProductOrder");
            PO.HasKey(po => new { po.orderId, po.productId });
            
            PO.HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.orderId);

            PO.HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.productId);
        }
    }
}
