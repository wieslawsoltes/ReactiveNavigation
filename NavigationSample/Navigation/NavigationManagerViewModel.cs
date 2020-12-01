using System.Linq;
using ReactiveUI;
using NavigationSample.Models;
using System.Reactive.Linq;

namespace NavigationSample.ViewModels
{
    public class NavigationManagerViewModel : ReactiveObject, INavigationManager
    {
        public static NavigationManagerViewModel Instance { get; private set; }

        public static void Register()
        {
            Instance = new NavigationManagerViewModel();
        }

        private INavigationControl _control;
        private INavigationStack _stack;

        private NavigationManagerViewModel()
        {
            Control = new NavigationControlViewModel(this);
            Stack = new NavigationStackViewModel();
        }

        public INavigationControl Control
        {
            get => _control;
            set => this.RaiseAndSetIfChanged(ref _control, value);
        }

        public INavigationStack Stack
        {
            get => _stack;
            set => this.RaiseAndSetIfChanged(ref _stack, value);
        }

        public void CloseContent()
        {
            Stack.ContentStack.Remove(_control.Content);
            _control.Content = null;
        }

        public void CloseLeftPane()
        {
            _control.LeftPane = null;
        }

        public void CloseRightPane()
        {
            _control.RightPane = null;
        }

        public void CloseStatus()
        {
            _control.Status = null;
        }

        public void CloseDialog()
        {
            Stack.DialogStack.Remove(_control.Dialog);
            _control.Dialog = null;
        }

        public void ClosePopup()
        {
            _control.Popup = null;
        }

        public void ClearContent()
        {
            Stack.ContentStack.Clear();
            _control.Content = null;
        }

        public void ClearDialog()
        {
            Stack.DialogStack.Clear();
            _control.Dialog = null;
        }

        public void NavigateContent(object content)
        {
            _control.Content = content;
            Stack.ContentStack.Add(content);
        }

        public void NavigateLeftPane(object pane)
        {
            _control.LeftPane = pane;
        }

        public void NavigateRightPane(object pane)
        {
            _control.RightPane = pane;
        }

        public void NavigateStatus(object pane)
        {
            _control.Status = pane;
        }

        public void NavigateDialog(object dialog)
        {
            _control.Dialog = dialog;
            Stack.DialogStack.Add(dialog);
        }

        public void NavigatePopup(object popup)
        {
            _control.Popup = popup;
        }

        public void GoBackContent()
        {
            if (Stack.ContentStack.Count <= 1)
            {
                return;
            }
            
            var last = Stack.ContentStack.LastOrDefault();
            if (last is { })
            {
                Stack.ContentStack.Remove(last);
                var back = Stack.ContentStack.LastOrDefault();
                if (back is { })
                {
                    _control.Content = back;
                }
            }
        }

        public void GoBackDialog()
        {
            if (Stack.DialogStack.Count <= 1)
            {
                return;
            }

            var last = Stack.DialogStack.LastOrDefault();
            if (last is { })
            {
                Stack.DialogStack.Remove(last);
                var back = Stack.DialogStack.LastOrDefault();
                if (back is { })
                {
                    _control.Dialog = back;
                }
            }
        }
    }
}