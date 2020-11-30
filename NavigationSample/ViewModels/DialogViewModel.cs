using System.Windows.Input;
using ReactiveUI;

namespace NavigationSample.ViewModels
{
    public class DialogViewModel : ViewModelBase
    {
        public DialogViewModel()
        {
            PopupCommand = ReactiveCommand.Create(
                () => NavigationManager.Instance.NavigatePopup(new PopupViewModel()));
        }

        public  ICommand PopupCommand { get; }
    }
}