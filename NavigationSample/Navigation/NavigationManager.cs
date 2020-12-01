using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Input;
using ReactiveUI;
using NavigationSample.Models;
using System.Reactive.Linq;

namespace NavigationSample.ViewModels
{
    public class NavigationManager : ReactiveObject, INavigationManager, INavigationControl, INavigationStack
    {
        public static NavigationManager Instance { get; private set; }

        public static void Register()
        {
            Instance = new NavigationManager();
        }

        private ObservableCollection<object> _contentStack;
        private ObservableCollection<object> _dialogStack;
        private bool _canContentNavigateBack;
        private bool _canDialogNavigateBack;
        private bool _isContentEnabled;
        private bool _isDialogEnabled;
        private object _content;
        private object _lefPane;
        private object _rightPane;
        private object _status;
        private object _dialog;
        private object _popup;

        private NavigationManager()
        {
            _contentStack = new ObservableCollection<object>();
            _dialogStack = new ObservableCollection<object>();

			Observable.FromEventPattern(ContentStack, nameof(ContentStack.CollectionChanged))
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(_ => CanContentNavigateBack = ContentStack.Count > 1);

			Observable.FromEventPattern(DialogStack, nameof(ContentStack.CollectionChanged))
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(_ => CanDialogNavigateBack = DialogStack.Count > 1);

            this.WhenAnyValue(
                    x => x.Dialog,
                    x => x.Popup,
                    (dialog, popup) => dialog is null && popup is null)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(x => IsContentEnabled = x);

            this.WhenAnyValue(x => x.Popup)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(x => IsDialogEnabled = x is null);

            CloseContentCommand = ReactiveCommand.Create<object>(x => CloseContent());
            CloseLeftPaneCommand = ReactiveCommand.Create<object>(x => CloseLeftPane());
            CloseRightPaneCommand = ReactiveCommand.Create<object>(x => CloseRightPane());
            CloseStatusCommand = ReactiveCommand.Create<object>(x => CloseStatus());
            CloseDialogCommand = ReactiveCommand.Create<object>(x => CloseDialog());
            ClosePopupCommand = ReactiveCommand.Create<object>(x => ClosePopup());
        }

        public ObservableCollection<object> ContentStack
        {
            get => _contentStack;
            private set => this.RaiseAndSetIfChanged(ref _contentStack, value);
        }

        public ObservableCollection<object> DialogStack
        {
            get => _dialogStack;
            private set => this.RaiseAndSetIfChanged(ref _dialogStack, value);
        }

        public bool CanContentNavigateBack
        {
            get => _canContentNavigateBack;
            private set => this.RaiseAndSetIfChanged(ref _canContentNavigateBack, value);
        }

        public bool CanDialogNavigateBack
        {
            get => _canDialogNavigateBack;
            private set => this.RaiseAndSetIfChanged(ref _canDialogNavigateBack, value);
        }

        public bool IsContentEnabled
        {
            get => _isContentEnabled;
            private set => this.RaiseAndSetIfChanged(ref _isContentEnabled, value);
        }

        public bool IsDialogEnabled
        {
            get => _isDialogEnabled;
            private set => this.RaiseAndSetIfChanged(ref _isDialogEnabled, value);
        }

        public object Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public object LeftPane
        {
            get => _lefPane;
            private set => this.RaiseAndSetIfChanged(ref _lefPane, value);
        }

        public object RightPane
        {
            get => _rightPane;
            private set => this.RaiseAndSetIfChanged(ref _rightPane, value);
        }

        public object Status
        {
            get => _status;
            private set => this.RaiseAndSetIfChanged(ref _status, value);
        }

        public object Dialog
        {
            get => _dialog;
            private set => this.RaiseAndSetIfChanged(ref _dialog, value);
        }

        public object Popup
        {
            get => _popup;
            private set => this.RaiseAndSetIfChanged(ref _popup, value);
        }

        public ICommand CloseContentCommand { get; }
        
        public ICommand CloseLeftPaneCommand { get; }

        public ICommand CloseRightPaneCommand { get; }

        public ICommand CloseStatusCommand { get; }
        
        public ICommand CloseDialogCommand { get; }

        public ICommand ClosePopupCommand { get; }
 
        public void CloseContent()
        {
            _contentStack.Remove(_content);
            Content = null;
        }

        public void CloseLeftPane()
        {
            LeftPane = null;
        }

        public void CloseRightPane()
        {
            RightPane = null;
        }

        public void CloseStatus()
        {
            Status = null;
        }

        public void CloseDialog()
        {
            _dialogStack.Remove(_dialog);
            Dialog = null;
        }

        public void ClosePopup()
        {
            Popup = null;
        }

        public void ClearContent()
        {
            _contentStack.Clear();
            Content = null;
        }

        public void ClearDialog()
        {
            _dialogStack.Clear();
            Dialog = null;
        }

        public void NavigateContent(object content)
        {
            Content = content;
            _contentStack.Add(content);
        }

        public void NavigateLeftPane(object pane)
        {
            LeftPane = pane;
        }

        public void NavigateRightPane(object pane)
        {
            RightPane = pane;
        }

        public void NavigateStatus(object pane)
        {
            Status = pane;
        }

        public void NavigateDialog(object dialog)
        {
            Dialog = dialog;
            _dialogStack.Add(dialog);
        }

        public void NavigatePopup(object popup)
        {
            Popup = popup;
        }

        public void GoBackContent()
        {
            if (_contentStack.Count <= 1)
            {
                return;
            }
            
            var last = _contentStack.LastOrDefault();
            if (last is { })
            {
                _contentStack.Remove(last);
                var back = _contentStack.LastOrDefault();
                if (back is { })
                {
                    Content = back;
                }
            }
        }

        public void GoBackDialog()
        {
            if (_dialogStack.Count <= 1)
            {
                return;
            }

            var last = _dialogStack.LastOrDefault();
            if (last is { })
            {
                _dialogStack.Remove(last);
                var back = _dialogStack.LastOrDefault();
                if (back is { })
                {
                    Dialog = back;
                }
            }
        }
    }
}