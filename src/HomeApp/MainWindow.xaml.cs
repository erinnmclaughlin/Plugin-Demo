using HomeApp.Plugins;
using System.Windows;

namespace HomeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PluginView _pluginView = new();

        public MainWindow()
        {
            _pluginView.OnSelectPlugin += HandleSelectPlugin;
            InitializeComponent();
            frame.Content = _pluginView;
        }

        private void HandleSelectPlugin(IPlugin plugin)
        {
            frame.Content = plugin;
        }
    }
}
