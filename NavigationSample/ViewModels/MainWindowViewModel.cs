namespace NavigationSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            NavigationManager.Register();
            NavigationManager.Instance.NavigateLeftPane(new LeftPaneViewModel());
            NavigationManager.Instance.NavigateContent(new HomeViewModel());
            Navigation = NavigationManager.Instance;
        }
        
        public NavigationManager Navigation { get; }
    }
}
