using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(x => new {x.CategoryId, x.ProductId });

            builder.HasOne(p => p.Product)
                .WithMany(cp => cp.CategoryProducts)
                .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Category)
               .WithMany(cp => cp.CategoryProducts)
               .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
