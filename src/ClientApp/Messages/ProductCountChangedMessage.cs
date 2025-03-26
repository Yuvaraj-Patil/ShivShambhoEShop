using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ShivShambho_eShop.ClientApp.Messages;

public class ProductCountChangedMessage(int count) : ValueChangedMessage<int>(count);
