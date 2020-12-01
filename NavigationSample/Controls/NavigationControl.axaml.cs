using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace NavigationSample.Controls
{
    public class NavigationControl : TemplatedControl
    {
        public static StyledProperty<bool> IsContentEnabledProperty =
            AvaloniaProperty.Register<NavigationControl, bool>(nameof(IsContentEnabled));

        public static StyledProperty<bool> IsDialogEnabledProperty =
            AvaloniaProperty.Register<NavigationControl, bool>(nameof(IsDialogEnabled));

        public static StyledProperty<object> ContentProperty =
            AvaloniaProperty.Register<NavigationControl, object>(nameof(Content));

        public static StyledProperty<object> LeftPaneProperty =
            AvaloniaProperty.Register<NavigationControl, object>(nameof(LeftPane));

        public static StyledProperty<object> RightPaneProperty =
            AvaloniaProperty.Register<NavigationControl, object>(nameof(RightPane));

        public static StyledProperty<object> StatusProperty =
            AvaloniaProperty.Register<NavigationControl, object>(nameof(Status));

        public static StyledProperty<object> DialogProperty =
            AvaloniaProperty.Register<NavigationControl, object>(nameof(Dialog));

        public static StyledProperty<object> PopupProperty =
            AvaloniaProperty.Register<NavigationControl, object>(nameof(Popup));

        public static StyledProperty<ICommand> CloseContentCommandProperty =
            AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseContentCommand));

        public static StyledProperty<ICommand> CloseLeftPaneCommandProperty =
            AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseLeftPaneCommand));

        public static StyledProperty<ICommand> CloseRightPaneCommandProperty =
            AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseRightPaneCommand));

        public static StyledProperty<ICommand> CloseStatusCommandProperty =
            AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseStatusCommand));

        public static StyledProperty<ICommand> CloseDialogCommandProperty =
            AvaloniaProperty.Register<NavigationControl, ICommand>(nameof(CloseDialogCommand));

        public static StyledProperty<ICommand> ClosePopupCommandProperty =
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
}
