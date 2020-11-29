using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ReactiveUI;

namespace NavigationSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            NavigationManagerViewModel.Register();
            NavigationManagerViewModel.Instance.NavigatePane(new PaneViewModel());
            NavigationManagerViewModel.Instance.NavigateContent(new HomeViewModel());
            Navigation = NavigationManagerViewModel.Instance;
        }
        
        public NavigationManagerViewModel Navigation { get; }
    }
}
