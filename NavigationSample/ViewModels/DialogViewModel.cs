using System.Windows.Input;
using NavigationControl.ViewModels.Navigation;
using ReactiveUI;

namespace NavigationSample.ViewModels;

public class DialogViewModel : ViewModelBase
{
    public DialogViewModel()
    {
        PopupCommand = ReactiveCommand.Create(
            () => NavigationManagerViewModel.Instance.NavigatePopup(new PopupViewModel()));
    }

    public  ICommand PopupCommand { get; }
}