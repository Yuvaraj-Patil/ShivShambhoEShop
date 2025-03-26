using System.Text.Json.Serialization;
using ShivShambho_eShop.ClientApp.Models.Catalog;
using ShivShambho_eShop.ClientApp.Models.Orders;
using ShivShambho_eShop.ClientApp.Models.Token;

namespace ShivShambho_eShop.ClientApp.Services;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    NumberHandling = JsonNumberHandling.AllowReadingFromString)]
[JsonSerializable(typeof(CancelOrderCommand))]
[JsonSerializable(typeof(CatalogBrand))]
[JsonSerializable(typeof(CatalogItem))]
[JsonSerializable(typeof(CatalogRoot))]
[JsonSerializable(typeof(CatalogType))]
[JsonSerializable(typeof(Models.Orders.Order))]
[JsonSerializable(typeof(Models.Location.Location))]
[JsonSerializable(typeof(UserToken))]
internal partial class ShivShambho_eShopJsonSerializerContext : JsonSerializerContext
{
}
