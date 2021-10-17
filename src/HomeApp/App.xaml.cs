using HomeApp.Plugins;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HomeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            List<Type> plugins = PluginService.GetPluginTypes();

            foreach (Type plugin in plugins)
            {
                _ = services.AddTransient(typeof(IPlugin), plugin);
                _ = services.AddTransient(plugin);
            }

            _ = services.AddSingleton<MainWindow>();
            _ = services.AddSingleton<PluginView>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _serviceProvider.GetService<MainWindow>().Show();
        }
    }
}
