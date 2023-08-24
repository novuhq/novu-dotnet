using Microsoft.Extensions.DependencyInjection;

namespace Novu.Sync;

public static class IocRegistrationExtensions
{
    public static IServiceCollection RegisterSync(this IServiceCollection services)
    {
        services.AddTransient<LayoutSync>();
        services.AddTransient<WorkflowGroupSync>();
        services.AddTransient<IntegrationSync>();
        services.AddTransient<WorkflowSync>();
        return services;
    }
}