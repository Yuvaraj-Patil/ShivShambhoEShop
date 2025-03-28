using ShivShambho_eShop.WebAppComponents.Catalog;

namespace ShivShambho_eShop.WebApp.Services
{
    public interface IBasketState
    {
        public Task<IReadOnlyCollection<BasketItem>> GetBasketItemsAsync();

        public Task AddAsync(CatalogItem item);
    }
}
