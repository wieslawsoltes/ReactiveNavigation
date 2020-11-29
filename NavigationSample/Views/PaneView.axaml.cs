using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NavigationSample.Views
{
    public class PaneView : UserControl
    {
        public PaneView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
