using HomeApp.Plugins;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HomeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<IPlugin> _plugins;

        public MainWindow()
        {
            _plugins = PluginService.GetPlugins();
            InitializeComponent();
            dataGrid.ItemsSource = _plugins;
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IPlugin plugin = (sender as DataGridRow).Item as IPlugin;
            UserControl control = plugin.Load();

            GetWindow(this).Content = control;
        }
    }
}
