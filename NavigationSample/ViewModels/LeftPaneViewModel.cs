﻿using System.Windows.Input;
using ReactiveUI;

namespace NavigationSample.ViewModels
{
    public class LeftPaneViewModel : ViewModelBase
    {
        public LeftPaneViewModel()
        {
            GoBackContentCommand = ReactiveCommand.Create(
                () => NavigationManagerViewModel.Instance.GoBackContent());
            
            GoBackDialogCommand = ReactiveCommand.Create(
                () => NavigationManagerViewModel.Instance.GoBackDialog());

            HomeCommand = ReactiveCommand.Create(
                () => NavigationManagerViewModel.Instance.NavigateContent(new HomeViewModel()));
        
            SettingsCommand = ReactiveCommand.Create(
                () => NavigationManagerViewModel.Instance.NavigateContent(new SettingsViewModel()));
            
            ToggleRightPaneCommand = ReactiveCommand.Create(
                () => 
                {
                    if (NavigationManagerViewModel.Instance.RightPane is { })
                    {
                        NavigationManagerViewModel.Instance.CloseRightPane();
                    }
                    else
                    {
                        NavigationManagerViewModel.Instance.NavigateRightPane(new RightPaneViewModel());
                    }
                });

            DialogCommand = ReactiveCommand.Create(
                () => NavigationManagerViewModel.Instance.NavigateDialog(new DialogViewModel()));

            PopupCommand = ReactiveCommand.Create(
                () => NavigationManagerViewModel.Instance.NavigatePopup(new PopupViewModel()));
        }

        public ICommand GoBackContentCommand { get; }
        
        public ICommand GoBackDialogCommand { get; }
        
        public ICommand HomeCommand { get; }
        
        public ICommand SettingsCommand { get; }

        public ICommand ToggleRightPaneCommand { get; }
    
        public ICommand DialogCommand { get; }

        public ICommand PopupCommand { get; }
    }
}