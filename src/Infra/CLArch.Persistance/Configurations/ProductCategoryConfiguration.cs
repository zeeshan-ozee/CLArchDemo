using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CLArch.Domain.Entities.Product;

namespace CLArch.Persistance.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<CLArch.Domain.Entities.Product.Category> builder)
    {
        builder.ToTable("Category");

        builder.Property(nameof(Category.IsDeleted)).IsRequired();


    }
}
