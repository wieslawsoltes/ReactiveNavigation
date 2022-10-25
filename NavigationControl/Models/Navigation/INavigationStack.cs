using System.Collections.ObjectModel;

namespace NavigationControl.Models.Navigation;

public interface INavigationStack
{
    ObservableCollection<object> ContentStack { get; }
    ObservableCollection<object> DialogStack { get; }
    bool CanContentNavigateBack { get; }
    bool CanDialogNavigateBack { get; }
}