using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NavigationSample.Views;

public class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}