using Microsoft.Extensions.DependencyInjection;
using Novu.Sync.Models;
using Novu.Sync.Services;

namespace Novu.Sync;

public static class IocRegistrationExtensions
{
    public static IServiceCollection RegisterNovuSync(this IServiceCollection services)
    {
        return services
            .AddTransient<INovuSync<TemplateLayout>, LayoutSync>()
            .AddTransient<INovuSync<TemplateWorkflowGroup>, WorkflowGroupSync>()
            .AddTransient<INovuSync<TemplateIntegration>, IntegrationSync>()
            .AddTransient<INovuSync<TemplateWorkflow>, WorkflowSync>();
    }
}