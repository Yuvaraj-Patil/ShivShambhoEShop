namespace ShivShambho_eShop.ClientApp.Services.Location;

public interface ILocationService
{
    Task UpdateUserLocation(Models.Location.Location newLocReq);
}
