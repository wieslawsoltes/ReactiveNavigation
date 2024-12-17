using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace ReactiveNavigation.Controls;

public class NavigationControl : TemplatedControl
{
    public static readonly StyledProperty<bool> IsContentEnabledProperty =
        AvaloniaProperty.Register<NavigationControl, bool>(nameof(IsContentEnabled));

    public static readonly StyledProperty<bool> IsDialogEnabledProperty =
        AvaloniaProperty.Register<NavigationControl, bool>(nameof(IsDialogEnabled));

    public static readonly StyledProperty<object> ContentProperty =
        AvaloniaProperty.Register<NavigationControl, object>(nameof(Content));

    public static readonly StyledProperty<object> LeftPaneProperty =
        AvaloniaProperty.Register<NavigationControl, object>(nameof(LeftPane));

    public static readonly StyledProperty<object> RightPaneProperty =
        AvaloniaProperty.Register<NavigationControl, object>(nameof(RightPane));

    public static readonly StyledProperty<object> StatusProperty =
        AvaloniaProperty.Register<NavigationControl, object>(nameof(Status));

    public static readonly StyledProperty<object> DialogProperty =
        AvaloniaProperty.Register<NavigationControl, object>(nameof(Dialog));

    public static readonly StyledProperty<object> PopupProperty =
        AvaloniaProperty.Register<NavigationControl, object>(nameof(Popup));

    public static readonly StyledProperty<ICommand> CloseContentCommandProperty =
        AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseContentCommand));

    public static readonly StyledProperty<ICommand> CloseLeftPaneCommandProperty =
        AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseLeftPaneCommand));

    public static readonly StyledProperty<ICommand> CloseRightPaneCommandProperty =
        AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseRightPaneCommand));

    public static readonly StyledProperty<ICommand> CloseStatusCommandProperty =
        AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseStatusCommand));

    public static readonly StyledProperty<ICommand> CloseDialogCommandProperty =
        AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseDialogCommand));

    public static readonly StyledProperty<ICommand> ClosePopupCommandProperty =
        AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(ClosePopupCommand));

    public bool IsContentEnabled
    {
        get => GetValue(IsContentEnabledProperty);
        set => SetValue(IsContentEnabledProperty, value);
    }

    public bool IsDialogEnabled
    {
        get => GetValue(IsDialogEnabledProperty);
        set => SetValue(IsDialogEnabledProperty, value);
    }

    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public object LeftPane
    {
        get => GetValue(LeftPaneProperty);
        set => SetValue(LeftPaneProperty, value);
    }

    public object RightPane
    {
        get => GetValue(RightPaneProperty);
        set => SetValue(RightPaneProperty, value);
    }

    public object Status
    {
        get => GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public object Dialog
    {
        get => GetValue(DialogProperty);
        set => SetValue(DialogProperty, value);
    }

    public object Popup
    {
        get => GetValue(PopupProperty);
        set => SetValue(PopupProperty, value);
    }

    public ICommand CloseContentCommand
    {
        get => GetValue(CloseContentCommandProperty);
        set => SetValue(CloseContentCommandProperty, value);
    }

    public ICommand CloseLeftPaneCommand
    {
        get => GetValue(CloseLeftPaneCommandProperty);
        set => SetValue(CloseLeftPaneCommandProperty, value);
    }

    public ICommand CloseRightPaneCommand
    {
        get => GetValue(CloseRightPaneCommandProperty);
        set => SetValue(CloseRightPaneCommandProperty, value);
    }

    public ICommand CloseStatusCommand
    {
        get => GetValue(CloseStatusCommandProperty);
        set => SetValue(CloseStatusCommandProperty, value);
    }

    public ICommand CloseDialogCommand
    {
        get => GetValue(CloseDialogCommandProperty);
        set => SetValue(CloseDialogCommandProperty, value);
    }

    public ICommand ClosePopupCommand
    {
        get => GetValue(ClosePopupCommandProperty);
        set => SetValue(ClosePopupCommandProperty, value);
    }
}
