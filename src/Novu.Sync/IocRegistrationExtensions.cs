using Microsoft.Extensions.DependencyInjection;
using Novu.Sync.Models;
using Novu.Sync.Services;

namespace Novu.Sync;

public static class IocRegistrationExtensions
{
    public static IServiceCollection RegisterNovuSync(this IServiceCollection services)
    {
        services.AddTransient<INovuSync<TemplateLayout>, LayoutSync>();
        services.AddTransient<INovuSync<TemplateWorkflowGroup>, WorkflowGroupSync>();
        services.AddTransient<INovuSync<TemplateIntegration>, IntegrationSync>();
        services.AddTransient<INovuSync<TemplateWorkflow>, WorkflowSync>();
        return services;
    }
}