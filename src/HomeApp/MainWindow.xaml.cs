using HomeApp.Domain.Repositories;
using HomeApp.Plugins;
using System.Windows;

namespace HomeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PluginView _pluginView;
        private readonly IUserRepository _userRepo;
        private bool _isLoggedIn;

        public MainWindow(PluginView pluginView, IUserRepository userRepo)
        {
            _pluginView = pluginView;
            _userRepo = userRepo;

            _pluginView.OnSelectPlugin += HandleSelectPlugin;
            InitializeComponent();

            // User is not logged in on startup
            loginLogoutButton.Content = "Login";
            frame.Content = _pluginView;
        }

        private void HandleSelectPlugin(IPlugin plugin)
        {
            frame.Content = plugin;
        }

        private async void loginLogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isLoggedIn)
            {
                // simulate login
                var user = await _userRepo.GetUserByUsername("emclaughlin");
                greetingText.Text = $"Hello, {user.FirstName} {user.LastName}";
                loginLogoutButton.Content = "Logout";
            }
            else
            {
                greetingText.Text = null;
                loginLogoutButton.Content = "Login";
            }

            _isLoggedIn = !_isLoggedIn;
        }
    }
}
