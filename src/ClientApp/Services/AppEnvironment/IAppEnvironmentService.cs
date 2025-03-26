using ShivShambho_eShop.ClientApp.Services.Basket;
using ShivShambho_eShop.ClientApp.Services.Catalog;
using ShivShambho_eShop.ClientApp.Services.Identity;
using ShivShambho_eShop.ClientApp.Services.Order;

namespace ShivShambho_eShop.ClientApp.Services.AppEnvironment;

public interface IAppEnvironmentService
{
    IBasketService BasketService { get; }

    ICatalogService CatalogService { get; }

    IOrderService OrderService { get; }

    IIdentityService IdentityService { get; }

    void UpdateDependencies(bool useMockServices);
}
