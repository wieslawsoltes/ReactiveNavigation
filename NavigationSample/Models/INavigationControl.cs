using System.Windows.Input;

namespace NavigationSample.Models
{
    public interface INavigationControl
    {
        bool IsContentEnabled { get; set; }
        bool IsDialogEnabled { get; set; }
        object Content { get; set; }
        object LeftPane { get; set; }
        object RightPane { get; set; }
        object Status { get; set; }
        object Dialog { get; set; }
        object Popup { get; set; }
        ICommand CloseContentCommand { get; }
        ICommand CloseLeftPaneCommand { get; }
        ICommand CloseRightPaneCommand { get; }
        ICommand CloseStatusCommand { get; }
        ICommand CloseDialogCommand { get; }
        ICommand ClosePopupCommand { get; }
    }
}