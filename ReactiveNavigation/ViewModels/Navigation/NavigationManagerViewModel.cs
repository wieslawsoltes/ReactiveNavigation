using System.Linq;
using ReactiveNavigation.Models.Navigation;
using ReactiveUI;

namespace ReactiveNavigation.ViewModels.Navigation;

public class NavigationManagerViewModel : ReactiveObject, INavigationManager
{
    public static NavigationManagerViewModel? Instance { get; private set; }

    public static void Register(INavigationControl control, INavigationStack stack)
    {
        Instance = new NavigationManagerViewModel(control, stack);
    }

    private NavigationManagerViewModel(INavigationControl control, INavigationStack stack)
    {
        Control = control;
        Stack = stack;
    }

    public INavigationControl Control { get; }

    public INavigationStack Stack { get; }

    public void CloseContent()
    {
        if (Control.Content == null)
        {
            return;
        }

        Stack.ContentStack.Remove(Control.Content);

        Control.Content = null;
    }

    public void CloseLeftPane()
    {
        Control.LeftPane = null;
    }

    public void CloseRightPane()
    {
        Control.RightPane = null;
    }

    public void CloseStatus()
    {
        Control.Status = null;
    }

    public void CloseDialog()
    {
        if (Control.Dialog == null)
        {
            return;
        }

        Stack.DialogStack.Remove(Control.Dialog);

        Control.Dialog = null;
    }

    public void ClosePopup()
    {
        Control.Popup = null;
    }

    public void ClearContent()
    {
        Stack.ContentStack.Clear();
        Control.Content = null;
    }

    public void ClearDialog()
    {
        Stack.DialogStack.Clear();
        Control.Dialog = null;
    }

    public void NavigateContent(object content)
    {
        Control.Content = content;
        Stack.ContentStack.Add(content);
    }

    public void NavigateLeftPane(object pane)
    {
        Control.LeftPane = pane;
    }

    public void NavigateRightPane(object pane)
    {
        Control.RightPane = pane;
    }

    public void NavigateStatus(object pane)
    {
        Control.Status = pane;
    }

    public void NavigateDialog(object dialog)
    {
        Control.Dialog = dialog;
        Stack.DialogStack.Add(dialog);
    }

    public void NavigatePopup(object popup)
    {
        Control.Popup = popup;
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
                Control.Content = back;
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
                Control.Dialog = back;
            }
        }
    }
}
