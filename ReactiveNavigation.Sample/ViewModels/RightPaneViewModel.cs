using System.Windows.Input;
using ReactiveNavigation.ViewModels.Navigation;
using ReactiveUI;

namespace ReactiveNavigation.Sample.ViewModels;

public class RightPaneViewModel : ViewModelBase
{
    public RightPaneViewModel()
    {
        ToggleStatusCommand = ReactiveCommand.Create(
            () => 
            {
                if (NavigationManagerViewModel.Instance?.Control.Status is { })
                {
                    NavigationManagerViewModel.Instance.CloseStatus();
                }
                else
                {
                    NavigationManagerViewModel.Instance?.NavigateStatus(new StatusViewModel());
                }
            });
    }

    public ICommand ToggleStatusCommand { get; }
}
