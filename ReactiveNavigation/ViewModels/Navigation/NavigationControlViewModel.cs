using System;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveNavigation.Models.Navigation;
using ReactiveUI;

namespace ReactiveNavigation.ViewModels.Navigation;

public partial class NavigationControlViewModel : ReactiveObject, INavigationControl
{
    public NavigationControlViewModel()
    {
        this.WhenAnyValue(
                x => x.Dialog,
                x => x.Popup,
                (dialog, popup) => dialog is null && popup is null)
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(x => IsContentEnabled = x);

        this.WhenAnyValue(x => x.Popup)
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(x => IsDialogEnabled = x is null);

        CloseContentCommand = ReactiveCommand.Create<object>(_ => _manager?.CloseContent());

        CloseLeftPaneCommand = ReactiveCommand.Create<object>(_ => _manager?.CloseLeftPane());

        CloseRightPaneCommand = ReactiveCommand.Create<object>(_ => _manager?.CloseRightPane());

        CloseStatusCommand = ReactiveCommand.Create<object>(_ => _manager?.CloseStatus());

        CloseDialogCommand = ReactiveCommand.Create<object>(_ => _manager?.CloseDialog());

        ClosePopupCommand = ReactiveCommand.Create<object>(_ => _manager?.ClosePopup());
    }

    [Reactive]
    public partial INavigationManager? Manager { get; set; }
    
    [Reactive]
    public partial bool IsContentEnabled { get; set; }
    
    [Reactive]
    public partial bool IsDialogEnabled { get; set; }
    
    [Reactive]
    public partial object? Content { get; set; }
    
    [Reactive]
    public partial object? LeftPane { get; set; }
    
    [Reactive]
    public partial object? RightPane { get; set; }
    
    [Reactive]
    public partial object? Status { get; set; }
    
    [Reactive]
    public partial object? Dialog { get; set; }
    
    [Reactive]
    public partial object? Popup { get; set; }
    
    public ICommand CloseContentCommand { get; }
        
    public ICommand CloseLeftPaneCommand { get; }

    public ICommand CloseRightPaneCommand { get; }

    public ICommand CloseStatusCommand { get; }
        
    public ICommand CloseDialogCommand { get; }

    public ICommand ClosePopupCommand { get; }
}
