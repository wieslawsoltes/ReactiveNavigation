using System.Windows.Input;
using ReactiveNavigation.ViewModels.Navigation;
using ReactiveUI;

namespace ReactiveNavigation.Sample.ViewModels;

public class DialogViewModel : ViewModelBase
{
    public DialogViewModel()
    {
        PopupCommand = ReactiveCommand.Create(
            () => NavigationManagerViewModel.Instance.NavigatePopup(new PopupViewModel()));
    }

    public  ICommand PopupCommand { get; }
}