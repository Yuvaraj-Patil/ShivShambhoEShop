using ShivShambho_eShop.WebAppComponents.Services;

namespace ShivShambho_eShop.WebApp.Services;

public class ProductImageUrlProvider : IProductImageUrlProvider
{
    public string GetProductImageUrl(int productId)
        => $"product-images/{productId}?api-version=2.0";
}
