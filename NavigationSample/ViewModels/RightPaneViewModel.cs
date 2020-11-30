using System.Windows.Input;
using ReactiveUI;

namespace NavigationSample.ViewModels
{
    public class RightPaneViewModel : ViewModelBase
    {
        public RightPaneViewModel()
        {
            ToggleStatusCommand = ReactiveCommand.Create(
                () => 
                {
                    if (NavigationManagerViewModel.Instance.Status is { })
                    {
                        NavigationManagerViewModel.Instance.CloseStatus();
                    }
                    else
                    {
                        NavigationManagerViewModel.Instance.NavigateStatus(new StatusViewModel());
                    }
                });
        }

        public ICommand ToggleStatusCommand { get; }
    }
}