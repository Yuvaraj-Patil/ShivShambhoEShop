using ShivShambho_eShop.WebAppComponents.Catalog;

namespace ShivShambho_eShop.WebAppComponents.Item;

public static class ItemHelper
{
    public static string Url(CatalogItem item)
        => $"item/{item.Id}";
}
