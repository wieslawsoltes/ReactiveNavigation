using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ReactiveNavigation.Sample.Views;

public class DialogView : UserControl
{
    public DialogView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}