﻿using ShivShambho_eShop.ClientApp.Models.Orders;
using ShivShambho_eShop.ClientApp.Services;
using ShivShambho_eShop.ClientApp.Services.AppEnvironment;
using ShivShambho_eShop.ClientApp.Services.Settings;
using ShivShambho_eShop.ClientApp.ViewModels.Base;

namespace ShivShambho_eShop.ClientApp.ViewModels;

public partial class ProfileViewModel : ViewModelBase
{
    private readonly IAppEnvironmentService _appEnvironmentService;
    private readonly ObservableCollectionEx<Order> _orders;
    private readonly ISettingsService _settingsService;

    [ObservableProperty] private Order _selectedOrder;

    public ProfileViewModel(
        IAppEnvironmentService appEnvironmentService, ISettingsService settingsService,
        INavigationService navigationService)
        : base(navigationService)
    {
        _appEnvironmentService = appEnvironmentService;
        _settingsService = settingsService;

        _orders = new ObservableCollectionEx<Order>();
    }

    public IList<Order> Orders => _orders;

    public override async Task InitializeAsync()
    {
        await RefreshAsync();
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        await IsBusyFor(
            async () =>
            {
                // Logout
                await NavigationService.NavigateToAsync(
                    "//Login",
                    new Dictionary<string, object> {{"Logout", true}});
            });
    }

    [RelayCommand]
    private async Task RefreshAsync()
    {
        if (IsBusy)
        {
            return;
        }

        await IsBusyFor(
            async () =>
            {
                // Get orders
                var orders = await _appEnvironmentService.OrderService.GetOrdersAsync();

                _orders.ReloadData(orders);
            });
    }

    [RelayCommand]
    private async Task OrderDetailAsync(Order order)
    {
        if (order is null || IsBusy)
        {
            return;
        }

        await NavigationService.NavigateToAsync(
            "OrderDetail",
            new Dictionary<string, object> {{nameof(Order.OrderNumber), order.OrderNumber}});
    }
}
