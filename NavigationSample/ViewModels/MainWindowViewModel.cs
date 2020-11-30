namespace NavigationSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            NavigationManagerViewModel.Register();
            NavigationManagerViewModel.Instance.NavigateLeftPane(new LeftPaneViewModel());
            NavigationManagerViewModel.Instance.NavigateContent(new HomeViewModel());
            Navigation = NavigationManagerViewModel.Instance;
        }
        
        public NavigationManagerViewModel Navigation { get; }
    }
}
