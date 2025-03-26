using ShivShambho_eShop.ClientApp.Models.Basket;

namespace ShivShambho_eShop.ClientApp.Services.Basket;

public interface IBasketService
{
    IEnumerable<BasketItem> LocalBasketItems { get; set; }
    Task<CustomerBasket> GetBasketAsync();
    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket);
    Task ClearBasketAsync();
}
