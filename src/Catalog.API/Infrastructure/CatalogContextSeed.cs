using System.Text.Json;
using ShivShambho_eShop.Catalog.API.Services;
using Pgvector;

namespace ShivShambho_eShop.Catalog.API.Infrastructure;

public partial class CatalogContextSeed(
    IWebHostEnvironment env,
    IOptions<CatalogOptions> settings,
    ICatalogAI catalogAI,
    ILogger<CatalogContextSeed> logger) : IDbSeeder<CatalogContext>
{
    public async Task SeedAsync(CatalogContext context)
    {
        var useCustomizationData = settings.Value.UseCustomizationData;
        var contentRootPath = env.ContentRootPath;
        var picturePath = env.WebRootPath;

        // Workaround from https://github.com/npgsql/efcore.pg/issues/292#issuecomment-388608426
        context.Database.OpenConnection();
        ((NpgsqlConnection)context.Database.GetDbConnection()).ReloadTypes();

        if (!context.CatalogItems.Any())
        {
            var sourcePath = Path.Combine(contentRootPath, "Setup", "catalog.json");
            var sourceJson = File.ReadAllText(sourcePath);
            var sourceItems = JsonSerializer.Deserialize<CatalogSourceEntry[]>(sourceJson);

            context.ProductCategory.RemoveRange(context.ProductCategory);
            await context.ProductCategory.AddRangeAsync(sourceItems.Select(x => x.Brand).Distinct()
                .Select(brandName => new ProductCategory { CategoryName = brandName }));
            logger.LogInformation("Seeded catalog with {NumBrands} brands", context.ProductCategory.Count());

            context.SubCategory.RemoveRange(context.SubCategory);
            await context.SubCategory.AddRangeAsync(sourceItems.Select(x => x.Type).Distinct()
                .Select(typeName => new SubCategory { SubCategoryName = typeName }));
            logger.LogInformation("Seeded catalog with {NumTypes} types", context.SubCategory.Count());

            await context.SaveChangesAsync();

            var brandIdsByName = await context.ProductCategory.ToDictionaryAsync(x => x.CategoryName, x => x.CategoryId);
            var typeIdsByName = await context.SubCategory.ToDictionaryAsync(x => x.SubCategoryName, x => x.SubCategoryId);

            var catalogItems = sourceItems.Select(source => new CatalogItem
            {
                ProductId = source.Id,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                CategoryId = brandIdsByName[source.Brand],
                SubCategoryId = typeIdsByName[source.Type],
                AvailableStock = 100,
                MaxStockThreshold = 200,
                RestockThreshold = 10,
                PictureFileName = $"{source.Id}.webp",
            }).ToArray();

            if (catalogAI.IsEnabled)
            {
                logger.LogInformation("Generating {NumItems} embeddings", catalogItems.Length);
                IReadOnlyList<Vector> embeddings = await catalogAI.GetEmbeddingsAsync(catalogItems);
                for (int i = 0; i < catalogItems.Length; i++)
                {
                    catalogItems[i].Embedding = embeddings[i];
                }
            }

            await context.CatalogItems.AddRangeAsync(catalogItems);
            logger.LogInformation("Seeded catalog with {NumItems} items", context.CatalogItems.Count());
            await context.SaveChangesAsync();
        }
    }

    private class CatalogSourceEntry
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
