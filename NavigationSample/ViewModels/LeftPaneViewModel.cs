using System.Windows.Input;
using ReactiveUI;

namespace NavigationSample.ViewModels
{
    public class LeftPaneViewModel : ViewModelBase
    {
        public LeftPaneViewModel()
        {
            GoBackContentCommand = ReactiveCommand.Create(
                () => NavigationManager.Instance.GoBackContent(),
                NavigationManager.Instance.WhenAnyValue(x => x.CanContentNavigateBack));

            GoBackDialogCommand = ReactiveCommand.Create(
                () => NavigationManager.Instance.GoBackDialog(),
                NavigationManager.Instance.WhenAnyValue(x => x.CanDialogNavigateBack));

            HomeCommand = ReactiveCommand.Create(
                () => NavigationManager.Instance.NavigateContent(new HomeViewModel()));
        
            SettingsCommand = ReactiveCommand.Create(
                () => NavigationManager.Instance.NavigateContent(new SettingsViewModel()));
            
            ToggleRightPaneCommand = ReactiveCommand.Create(
                () => 
                {
                    if (NavigationManager.Instance.RightPane is { })
                    {
                        NavigationManager.Instance.CloseRightPane();
                    }
                    else
                    {
                        NavigationManager.Instance.NavigateRightPane(new RightPaneViewModel());
                    }
                });

            DialogCommand = ReactiveCommand.Create(
                () => NavigationManager.Instance.NavigateDialog(new DialogViewModel()));

            PopupCommand = ReactiveCommand.Create(
                () => NavigationManager.Instance.NavigatePopup(new PopupViewModel()));
        }

        public ICommand GoBackContentCommand { get; }
        
        public ICommand GoBackDialogCommand { get; }
        
        public ICommand HomeCommand { get; }
        
        public ICommand SettingsCommand { get; }

        public ICommand ToggleRightPaneCommand { get; }
    
        public ICommand DialogCommand { get; }

        public ICommand PopupCommand { get; }
    }
}