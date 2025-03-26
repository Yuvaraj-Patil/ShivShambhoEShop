using ShivShambho_eShop.ClientApp.Services;
using ShivShambho_eShop.ClientApp.ViewModels.Base;

namespace ShivShambho_eShop.ClientApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel(INavigationService navigationService)
        : base(navigationService)
    {
    }

    [RelayCommand]
    private async Task SettingsAsync()
    {
        await NavigationService.NavigateToAsync("Settings");
    }
}
