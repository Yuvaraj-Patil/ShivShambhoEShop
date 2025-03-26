namespace ShivShambho_eShop.ClientApp.Views;

public partial class BasketView
{
    public BasketView(BasketViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}
