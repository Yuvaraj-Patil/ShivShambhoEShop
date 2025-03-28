namespace ShivShambho_eShop.ClientApp.Services;

public interface IDialogService
{
    Task ShowAlertAsync(string message, string title, string buttonLabel);
}
