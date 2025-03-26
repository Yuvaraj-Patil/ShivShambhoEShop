using ShivShambho_eShop.ClientApp.Models.Basket;
using ShivShambho_eShop.ClientApp.Models.Catalog;
using ShivShambho_eShop.ClientApp.Models.Marketing;

namespace ShivShambho_eShop.ClientApp.Services.FixUri;

public interface IFixUriService
{
    void FixCatalogItemPictureUri(IEnumerable<CatalogItem> catalogItems);
    void FixBasketItemPictureUri(IEnumerable<BasketItem> basketItems);
    void FixCampaignItemPictureUri(IEnumerable<CampaignItem> campaignItems);
}
