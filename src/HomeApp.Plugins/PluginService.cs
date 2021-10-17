using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HomeApp.Plugins
{
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
}
