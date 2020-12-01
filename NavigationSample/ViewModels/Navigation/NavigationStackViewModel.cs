using System.Collections.ObjectModel;
using System;
using ReactiveUI;
using NavigationSample.Models.Navigation;
using System.Reactive.Linq;

namespace NavigationSample.ViewModels.Navigation
{
    public class NavigationStackViewModel : ReactiveObject, INavigationStack
    {
        private ObservableCollection<object> _contentStack;
        private ObservableCollection<object> _dialogStack;
        private bool _canContentNavigateBack;
        private bool _canDialogNavigateBack;

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
 
    }
}