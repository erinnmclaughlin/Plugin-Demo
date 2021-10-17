using HomeApp.Plugins;
using System.Windows.Controls;

namespace GreetingPlugin
{
    /// <summary>
    /// Interaction logic for GreetingControl.xaml
    /// </summary>
    public partial class GreetingControl : UserControl, IPlugin
    {
        public GreetingControl()
        {
            InitializeComponent();
        }

        public string Title => "Greeting Service";

        public string Description => "A service that greets you!";

        public UserControl Load() => this;
    }
}
