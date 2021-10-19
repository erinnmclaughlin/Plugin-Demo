using HomeApp.Domain.Services;
using HomeApp.Plugins;
using System.Windows;

namespace HomeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAuthenticationService _authService;
        private readonly PluginView _pluginView;

        public MainWindow(IAuthenticationService authService, PluginView pluginView)
        {
            _authService = authService;
            _pluginView = pluginView;

            _pluginView.OnSelectPlugin += HandleSelectPlugin;
            InitializeComponent();

            // User is not logged in on startup
            loginLogoutButton.Content = "Login";
            frame.Content = _pluginView;
        }

        private void HandleSelectPlugin(IPlugin plugin)
        {
            frame.Content = plugin.Load();
        }

        private async void loginLogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (_authService.IsLoggedIn)
            {
                greetingText.Text = null;
                loginLogoutButton.Content = "Login";
                _authService.Logout();
                return;
            }

            var user = await _authService.Login();
            greetingText.Text = $"Hello, {user.FirstName} {user.LastName}";
            loginLogoutButton.Content = "Logout";
        }
    }
}
