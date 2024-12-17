using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using ReactiveNavigation.Models.Navigation;
using ReactiveUI;

namespace ReactiveNavigation.ViewModels.Navigation;

public partial class NavigationStackViewModel : ReactiveObject, INavigationStack
{
    public NavigationStackViewModel()
    {
        _contentStack = new ObservableCollection<object>();
        _dialogStack = new ObservableCollection<object>();

        Observable.FromEventPattern(ContentStack, nameof(ContentStack.CollectionChanged))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(_ => CanContentNavigateBack = ContentStack.Count > 1);

        Observable.FromEventPattern(DialogStack, nameof(ContentStack.CollectionChanged))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(_ => CanDialogNavigateBack = DialogStack.Count > 1);
    }

    [Reactive]
    public partial ObservableCollection<object> ContentStack { get; private set; }
    
    [Reactive]
    public partial ObservableCollection<object> DialogStack { get; private set; }
    
    [Reactive]
    public partial bool CanContentNavigateBack { get; private set; }
    
    [Reactive]
    public partial bool CanDialogNavigateBack { get; private set; }
}
