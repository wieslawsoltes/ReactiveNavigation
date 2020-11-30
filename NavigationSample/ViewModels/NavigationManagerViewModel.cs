using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace NavigationSample.ViewModels
{
    public class NavigationManagerViewModel : ViewModelBase
    {
        public static NavigationManagerViewModel Instance { get; private set; }

        public static void Register()
        {
            Instance = new NavigationManagerViewModel();
        }

        private ObservableCollection<ViewModelBase> _contentStack;
        private ObservableCollection<ViewModelBase> _dialogStack;
        private ViewModelBase _currentPane;
        private ViewModelBase _currentContent;
        private ViewModelBase _currentDialog;

        private NavigationManagerViewModel()
        {
            _contentStack = new ObservableCollection<ViewModelBase>();
            _dialogStack = new ObservableCollection<ViewModelBase>();

            ClosePaneCommand = ReactiveCommand.Create<ViewModelBase>(x => ClosePane(x));
            
            CloseContentCommand = ReactiveCommand.Create<ViewModelBase>(x => CloseContent(x));

            CloseDialogCommand = ReactiveCommand.Create<ViewModelBase>(x => CloseDialog(x));
        }

        public ObservableCollection<ViewModelBase> ContentStack
        {
            get => _contentStack;
            private set => this.RaiseAndSetIfChanged(ref _contentStack, value);
        }

        public ObservableCollection<ViewModelBase> DialogStack
        {
            get => _dialogStack;
            private set => this.RaiseAndSetIfChanged(ref _dialogStack, value);
        }

        public ViewModelBase CurrentPane
        {
            get => _currentPane;
            private set => this.RaiseAndSetIfChanged(ref _currentPane, value);
        }

        public ViewModelBase CurrentContent
        {
            get => _currentContent;
            private set => this.RaiseAndSetIfChanged(ref _currentContent, value);
        }

        public ViewModelBase CurrentDialog
        {
            get => _currentDialog;
            private set => this.RaiseAndSetIfChanged(ref _currentDialog, value);
        }

        public  ICommand ClosePaneCommand { get; }
        
        public  ICommand CloseContentCommand { get; }
        
        public  ICommand CloseDialogCommand { get; }
 
        private void ClosePane(ViewModelBase pane)
        {
            CurrentPane = null;
        }

        private void CloseContent(ViewModelBase content)
        {
            _contentStack.Remove(content);
            CurrentContent = null;
        }

        private void CloseDialog(ViewModelBase dialog)
        {
            _dialogStack.Remove(dialog);
            CurrentDialog = null;
        }

        private void ClearContent()
        {
            _contentStack.Clear();
            CurrentContent = null;
        }

        private void ClearDialog()
        {
            _dialogStack.Clear();
            CurrentDialog = null;
        }

        public void NavigatePane(ViewModelBase pane)
        {
            CurrentPane = pane;
        }

        public void NavigateContent(ViewModelBase content)
        {
            CurrentContent = content;
            _contentStack.Add(content);
        }

        public void NavigateDialog(ViewModelBase dialog)
        {
            CurrentDialog = dialog;
            _dialogStack.Add(dialog);
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
                    CurrentContent = back;
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
                    CurrentDialog = back;
                }
            }
        }
    }
}