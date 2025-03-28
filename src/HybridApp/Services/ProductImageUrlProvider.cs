using ShivShambho_eShop.WebAppComponents.Services;

namespace ShivShambho_eShop.HybridApp.Services;

public class ProductImageUrlProvider : IProductImageUrlProvider
{
    public string GetProductImageUrl(int productId)
        => $"{MauiProgram.MobileBffHost}api/catalog/items/{productId}/pic?api-version=2.0";
}
