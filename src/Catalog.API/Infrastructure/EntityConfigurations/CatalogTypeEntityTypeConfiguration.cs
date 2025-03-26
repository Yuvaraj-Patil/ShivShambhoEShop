namespace ShivShambho_eShop.Catalog.API.Infrastructure.EntityConfigurations;

class SubCategoryEntityTypeConfiguration
    : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.ToTable("SubCategory");

        builder.Property(cb => cb.SubCategoryName)
            .HasMaxLength(100);
    }
}
