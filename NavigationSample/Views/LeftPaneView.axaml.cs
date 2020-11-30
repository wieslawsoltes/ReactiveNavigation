using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NavigationSample.Views
{
    public class LeftPaneView : UserControl
    {
        public LeftPaneView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
