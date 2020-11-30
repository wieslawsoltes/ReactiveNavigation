using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NavigationSample.Views
{
    public class RightPaneView : UserControl
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
}
