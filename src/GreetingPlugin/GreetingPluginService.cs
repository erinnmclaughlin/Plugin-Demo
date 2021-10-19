using HomeApp.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace GreetingPlugin
{
    public class GreetingPluginService : IPluginService
    {
        public void RegisterPluginServices(IServiceCollection services)
        {
            _ = services.AddTransient<GreetingControl>();
        }
    }
}
