using System.Windows.Input;

namespace NavigationSample.Models
{
    public interface INavigationControl
    {
        bool IsContentEnabled { get; }
        bool IsDialogEnabled { get; }
        object Content { get; }
        object LeftPane { get; }
        object RightPane { get; }
        object Status { get; }
        object Dialog { get; }
        object Popup { get; }
        ICommand CloseContentCommand { get; }
        ICommand CloseLeftPaneCommand { get; }
        ICommand CloseRightPaneCommand { get; }
        ICommand CloseStatusCommand { get; }
        ICommand CloseDialogCommand { get; }
        ICommand ClosePopupCommand { get; }
    }
}