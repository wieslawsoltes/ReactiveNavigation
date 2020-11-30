using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NavigationSample.Views
{
    public class PopupView : UserControl
    {
        public PopupView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
