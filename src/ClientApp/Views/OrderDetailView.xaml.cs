﻿namespace ShivShambho_eShop.ClientApp.Views;

public partial class OrderDetailView
{
    public OrderDetailView(OrderDetailViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}
