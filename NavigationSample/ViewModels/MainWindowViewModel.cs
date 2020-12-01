using NavigationSample.Models;

namespace NavigationSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Control = new NavigationControlViewModel();
            Stack = new NavigationStackViewModel();

            NavigationManagerViewModel.Register(Control, Stack);
            Manager = NavigationManagerViewModel.Instance;
            Control.Manager = NavigationManagerViewModel.Instance;

            NavigationManagerViewModel.Instance.NavigateLeftPane(new LeftPaneViewModel());
            NavigationManagerViewModel.Instance.NavigateContent(new HomeViewModel());
            NavigationManagerViewModel.Instance.NavigateStatus(new StatusViewModel());
        }

        public INavigationControl Control { get; }

        public INavigationStack Stack { get; }

        public INavigationManager Manager { get; }
    }
}
