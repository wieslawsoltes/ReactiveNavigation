using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NavigationSample.Views
{
    public class NavigationManagerView : UserControl
    {
        public NavigationManagerView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
