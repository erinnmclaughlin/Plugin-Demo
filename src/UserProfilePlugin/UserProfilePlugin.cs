using HomeApp.Plugins;
using System.Windows.Controls;

namespace UserProfilePlugin
{
    public class UserProfilePlugin : IPlugin
    {
        private readonly UserProfileControl _control;

        public UserProfilePlugin(UserProfileControl control)
        {
            _control = control;
        }

        public string Title => "User Profile Plugin";
        public string Description => "Displays informaation about the current user.";

        public UserControl Load()
        {
            return _control;
        }
    }
}
