using Microsoft.Extensions.DependencyInjection;

namespace HomeApp.Plugins
{
    public interface IPluginService
    {
        void RegisterPluginServices(IServiceCollection services);
    }
}
