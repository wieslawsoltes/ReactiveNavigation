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
                    if (NavigationManager.Instance.Status is { })
                    {
                        NavigationManager.Instance.CloseStatus();
                    }
                    else
                    {
                        NavigationManager.Instance.NavigateStatus(new StatusViewModel());
                    }
                });
        }

        public ICommand ToggleStatusCommand { get; }
    }
}