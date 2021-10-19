using HomeApp.Plugins;
using System.Windows.Controls;

namespace GreetingPlugin
{
    public class GreetingPlugin : IPlugin
    {
        private readonly GreetingControl _control;

        public GreetingPlugin(GreetingControl control)
        {
            _control = control;
        }

        public string Title => "Greeting Service";

        public string Description => "A service that greets you!";

        public UserControl Load()
        {
            return _control;
        }
    }
}
