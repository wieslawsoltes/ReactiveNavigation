using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ReactiveNavigation.Sample.Views;

public partial class RightPaneView : UserControl
{
    public RightPaneView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
