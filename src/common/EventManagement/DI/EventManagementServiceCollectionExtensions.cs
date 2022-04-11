using Microsoft.Extensions.DependencyInjection;

namespace EventManagement.DI;
public static class EventManagementServiceCollectionExtensions
{
    public static IServiceCollection AddEventPublisher(this IServiceCollection services)
    {
        return services;
    }
}