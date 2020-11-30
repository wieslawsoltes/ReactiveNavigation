namespace NavigationSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            NavigationManager.Register();
            NavigationManager.Instance.NavigateLeftPane(new LeftPaneViewModel());
            NavigationManager.Instance.NavigateContent(new HomeViewModel());
            NavigationManager.Instance.NavigateStatus(new StatusViewModel());
            Navigation = NavigationManager.Instance;
        }

        public NavigationManager Navigation { get; }
    }
}
