using System;
using System.Windows.Input;
using ReactiveUI;
using NavigationSample.Models.Navigation;
using System.Reactive.Linq;

namespace NavigationSample.ViewModels.Navigation
{
    public class NavigationControlViewModel : ReactiveObject, INavigationControl
    {
        private INavigationManager _manager;
        private bool _isContentEnabled;
        private bool _isDialogEnabled;
        private object _content;
        private object _lefPane;
        private object _rightPane;
        private object _status;
        private object _dialog;
        private object _popup;

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

            CloseContentCommand = ReactiveCommand.Create<object>(x => _manager?.CloseContent());

            CloseLeftPaneCommand = ReactiveCommand.Create<object>(x => _manager?.CloseLeftPane());

            CloseRightPaneCommand = ReactiveCommand.Create<object>(x => _manager?.CloseRightPane());

            CloseStatusCommand = ReactiveCommand.Create<object>(x => _manager?.CloseStatus());

            CloseDialogCommand = ReactiveCommand.Create<object>(x => _manager?.CloseDialog());

            ClosePopupCommand = ReactiveCommand.Create<object>(x => _manager?.ClosePopup());
        }
        public INavigationManager Manager
        {
            get => _manager;
            set => this.RaiseAndSetIfChanged(ref _manager, value);
        }

        public bool IsContentEnabled
        {
            get => _isContentEnabled;
            set => this.RaiseAndSetIfChanged(ref _isContentEnabled, value);
        }

        public bool IsDialogEnabled
        {
            get => _isDialogEnabled;
            set => this.RaiseAndSetIfChanged(ref _isDialogEnabled, value);
        }

        public object Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public object LeftPane
        {
            get => _lefPane;
            set => this.RaiseAndSetIfChanged(ref _lefPane, value);
        }

        public object RightPane
        {
            get => _rightPane;
            set => this.RaiseAndSetIfChanged(ref _rightPane, value);
        }

        public object Status
        {
            get => _status;
            set => this.RaiseAndSetIfChanged(ref _status, value);
        }

        public object Dialog
        {
            get => _dialog;
            set => this.RaiseAndSetIfChanged(ref _dialog, value);
        }

        public object Popup
        {
            get => _popup;
            set => this.RaiseAndSetIfChanged(ref _popup, value);
        }

        public ICommand CloseContentCommand { get; }
        
        public ICommand CloseLeftPaneCommand { get; }

        public ICommand CloseRightPaneCommand { get; }

        public ICommand CloseStatusCommand { get; }
        
        public ICommand CloseDialogCommand { get; }

        public ICommand ClosePopupCommand { get; }
    }
}