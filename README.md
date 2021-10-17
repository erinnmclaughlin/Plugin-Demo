# Plugin-Demo
Demonstrates using and developing plugins in WPF

### How it works
The main app, `HomeApp`, has a reference to `HomeApp.Plugins` which contains two items:

- `IPlugin`, which defines the "contract" of a plugin for the app:
```csharp
// IPlugin.cs
public interface IPlugin
{
    string Title { get; }
    string Description { get; }

    UserControl Load();
}
```

- `PluginService`, which uses reflection to search for plugins in a pre-defined folder
```csharp
// PluginService.cs
public class PluginService
{
    public static List<IPlugin> GetPlugins()
    {
        List<IPlugin> plugins = new();

        string[] files = Directory.GetFiles("Extensions", "*.dll");

        foreach (string file in files)
        {
            Assembly assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));
            IEnumerable<Type> pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

            foreach (Type pluginType in pluginTypes)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
                plugins.Add(plugin);
            }
        }

        return plugins;
    }
}
```

When loaded, the main app will use the `PluginService` to get a list of available plugins. A link to each plugin is shown in the default view. Double clicking the link will get the UserControl associated with that plugin, and set it as the main frame's content.
