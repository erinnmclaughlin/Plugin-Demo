using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HomeApp.Plugins
{
    public class PluginService
    {
        public static List<Type> GetPluginTypes()
        {
            string[] files = Directory.GetFiles("Extensions", "*.dll");

            return files.SelectMany(x =>
            {
                Assembly assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), x));
                return assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);
            }).ToList();
        }
    }
}
