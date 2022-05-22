using Microsoft.Extensions.DependencyInjection;

using Kernel.OperationResultUtils.Implementation;

namespace Kernel.OperationResultUtils.DI;

public static class OperationResultUtilsExtensions
{
    public static IServiceCollection AddOperationResultWrapper(this IServiceCollection services)
    {
        if (services == null) return services;
            
        return services
            .AddTransient<IOperationResultWrapper, OperationResultWrapper>();        
    }
}