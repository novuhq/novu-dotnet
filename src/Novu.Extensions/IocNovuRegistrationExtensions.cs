using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Novu.Interfaces;
using Novu.NotificationTemplates;
using Refit;

namespace Novu.Extensions;

public static class IocNovuRegistrationExtensions
{
    /// <summary>
    ///     Register Api client for Refit
    /// </summary>
    public static IServiceCollection RegisterNovuClients(
        this IServiceCollection services,
        IConfiguration configuration,
        RefitSettings refitSettings = null)
    {
        var novuConfiguration = configuration.GetNovuClientConfiguration();

        Action<HttpClient> configureClient = c =>
        {
            c.BaseAddress = new Uri(novuConfiguration.Url);

            // allow for multiple registrations—authorization cannot have multiple entries
            if (c.DefaultRequestHeaders.Contains("Authorization"))
            {
                c.DefaultRequestHeaders.Remove("Authorization");
            }

            c.DefaultRequestHeaders.Add("Authorization", $"ApiKey {novuConfiguration.ApiKey}");
        };
        var settings = refitSettings ?? new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(NovuClient.DefaultSerializerSettings),
        };

        services.AddRefitClient<ISubscriberClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IEventClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<ITopicClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IWorkflowGroupClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<INotificationTemplatesClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IWorkflowClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<ILayoutClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IIntegrationClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<INotificationsClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IMessageClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IExecutionDetailsClient>(settings).ConfigureHttpClient(configureClient);

        return services
            .AddTransient<INovuClient, NovuClient>();
    }
}