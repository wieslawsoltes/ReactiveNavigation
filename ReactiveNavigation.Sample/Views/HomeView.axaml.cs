using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ReactiveNavigation.Sample.Views;

public class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}