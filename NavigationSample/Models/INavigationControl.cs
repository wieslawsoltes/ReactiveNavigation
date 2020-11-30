using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NavigationSample.Models
{
    public interface INavigationControl
    {
        ObservableCollection<object> ContentStack { get; }
        ObservableCollection<object> DialogStack { get; }
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
        void CloseContent();
        void CloseLeftPane();
        void CloseRightPane();
        void CloseStatus();
        void CloseDialog();
        void ClosePopup();
        void ClearContent();
        void ClearDialog();
        void NavigateContent(object content);
        void NavigateLeftPane(object pane);
        void NavigateRightPane(object pane);
        void NavigateStatus(object pane);
        void NavigateDialog(object dialog);
        void NavigatePopup(object popup);
        void GoBackContent();
        void GoBackDialog();
    }
}