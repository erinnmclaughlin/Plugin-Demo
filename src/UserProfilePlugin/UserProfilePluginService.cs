using HomeApp.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace UserProfilePlugin
{
    public class UserProfilePluginService : IPluginService
    {
        public void RegisterPluginServices(IServiceCollection services)
        {
            _ = services.AddTransient<UserProfileControl>();
        }
    }
}
