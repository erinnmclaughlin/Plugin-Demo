using System.Windows.Controls;

namespace HomeApp.Plugins
{
    public interface IPlugin
    {
        string Title { get; }
        string Description { get; }

        UserControl Load();
    }
}
