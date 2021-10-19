using HomeApp.Plugins;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace HomeApp
{
    /// <summary>
    /// Interaction logic for PluginView.xaml
    /// </summary>
    public partial class PluginView : UserControl
    {
        private readonly List<IPlugin> _plugins;

        public delegate void PluginClickHandler(IPlugin plugin);

        public event PluginClickHandler OnSelectPlugin;

        public PluginView(IEnumerable<IPlugin> plugins)
        {
            _plugins = plugins.ToList();
            InitializeComponent();
            dataGrid.ItemsSource = _plugins;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var plugin = (sender as DataGridRow)!.Item as IPlugin;
            OnSelectPlugin?.Invoke(plugin);
        }
    }
}
