using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HomeApp.Plugins
{
    public class PluginService
    {
        private static readonly string[] _files = Directory.GetFiles("Extensions", "*.dll");

        public static List<Type> GetTypes<T>()
        {
            try
            {
                return _files.SelectMany(x =>
                {
                    Assembly assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), x));
                    return assembly.GetTypes().Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface);
                }).ToList();
            }
            catch
            {
                return new List<Type>();
            }
        }
    }
}
