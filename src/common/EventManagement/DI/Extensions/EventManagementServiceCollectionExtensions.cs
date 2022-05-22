using Microsoft.Extensions.DependencyInjection;

using EventManagement.DI.Configurators;

namespace EventManagement.DI.Extensions;
public static class EventManagementServiceCollectionExtensions
{
    public static IServiceCollection AddEventManager(this IServiceCollection services, Action<IServiceCollectionConfigurator> configurator)
    {
        return services;
    }
}
