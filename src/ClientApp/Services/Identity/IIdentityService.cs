using ShivShambho_eShop.ClientApp.Models.User;

namespace ShivShambho_eShop.ClientApp.Services.Identity;

public interface IIdentityService
{
    Task<bool> SignInAsync();

    Task<bool> SignOutAsync();

    Task<UserInfo> GetUserInfoAsync();

    Task<string> GetAuthTokenAsync();
}
