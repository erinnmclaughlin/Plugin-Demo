using HomeApp.Db;
using HomeApp.Domain.Services;
using HomeApp.Plugins;
using HomeApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            _ = RegisterPlugins(services);
            _ = RegisterServices(services);
            _ = RegisterViews(services);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>().Show();
        }

        private static IServiceCollection RegisterPlugins(ServiceCollection services)
        {
            PluginService.GetTypes<IPlugin>().ForEach(plugin => services.AddTransient(typeof(IPlugin), plugin));
            PluginService.GetTypes<IPluginService>().ForEach(service => services.AddTransient(typeof(IPluginService), service));

            var serviceProvider = services.BuildServiceProvider();

            foreach (var service in serviceProvider.GetServices<IPluginService>())
            {
                service.RegisterPluginServices(services);
            }

            return services;
        }

        private static IServiceCollection RegisterServices(ServiceCollection services)
        {
            return services.AddDbContext<HomeAppContext>(options => options.UseInMemoryDatabase("DemoDb"))
                .AddScoped<IAuthenticationService, AuthenticationService>();
        }

        private static IServiceCollection RegisterViews(ServiceCollection services)
        {
            return services.AddSingleton<MainWindow>()
                           .AddSingleton<PluginView>();
        }
    }
}
