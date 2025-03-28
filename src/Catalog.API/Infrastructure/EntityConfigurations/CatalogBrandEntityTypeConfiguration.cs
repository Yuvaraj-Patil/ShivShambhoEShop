namespace ShivShambho_eShop.Catalog.API.Infrastructure.EntityConfigurations;

class ProductCategoryEntityTypeConfiguration
    : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategory");

        builder.Property(cb => cb.CategoryName)
            .HasMaxLength(100);
    }
}
