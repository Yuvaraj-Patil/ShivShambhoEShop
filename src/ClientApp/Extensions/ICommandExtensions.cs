using System.Windows.Input;

namespace ShivShambho_eShop.ClientApp;

public static class ICommandExtensions
{
    public static void AttemptNotifyCanExecuteChanged<TCommand>(this TCommand command)
        where TCommand : ICommand
    {
        if (command is IRelayCommand rc)
        {
            rc?.NotifyCanExecuteChanged();
        }
    }
}
