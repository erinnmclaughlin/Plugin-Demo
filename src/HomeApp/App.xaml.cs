using HomeApp.Db;
using HomeApp.Domain.Repositories;
using HomeApp.Plugins;
using HomeApp.Repositories;
using Microsoft.EntityFrameworkCore;
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
            _ = RegisterPlugins(services);
            _ = RegisterServices(services);
            _ = RegisterViews(services);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _serviceProvider.GetService<MainWindow>().Show();
        }

        private static IServiceCollection RegisterPlugins(ServiceCollection services)
        {
            PluginService.GetPluginTypes()
                .ForEach(plugin => services.AddTransient(typeof(IPlugin), plugin));

            return services;
        }

        private static IServiceCollection RegisterServices(ServiceCollection services)
        {
            return services.AddDbContext<HomeAppContext>(options => options.UseInMemoryDatabase("DemoDb"))
                .AddScoped<IUserRepository, UserRepository>();
        }

        private static IServiceCollection RegisterViews(ServiceCollection services)
        {
            return services.AddSingleton<MainWindow>()
                           .AddSingleton<PluginView>();
        }
    }
}
