namespace ReactiveNavigation.Models.Navigation;

public interface INavigationManager
{
    INavigationControl Control { get; }
    INavigationStack Stack { get; }
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