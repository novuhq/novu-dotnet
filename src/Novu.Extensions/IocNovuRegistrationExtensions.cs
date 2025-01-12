using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Novu.Clients;
using Novu.Domain;
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

        Action<HttpClient> configureClient = client =>
        {
            client.BaseAddress = new Uri(novuConfiguration.Url);

            // allow for multiple registrations—authorization cannot have multiple entries
            if (client.DefaultRequestHeaders.Contains("Authorization"))
            {
                client.DefaultRequestHeaders.Remove("Authorization");
            }

            client.DefaultRequestHeaders.Add("Authorization", $"ApiKey {novuConfiguration.ApiKey}");
        };
        var settings = RefitSettings(refitSettings);

        services.AddRefitClient<ISubscriberClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IEventClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<ITopicClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IWorkflowClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IWorkflowGroupClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IWorkflowOverrideClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<ILayoutClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IIntegrationClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<INotificationsClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IMessageClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IExecutionDetailsClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IFeedClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IChangeClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<ITenantClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IMxRecordClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IOrganizationClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IOrganizationBrandClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IOrganizationMemberClient>(settings).ConfigureHttpClient(configureClient);
        services.AddRefitClient<IEnvironmentClient>(settings).ConfigureHttpClient(configureClient);

        return services
            .AddTransient<INovuClientConfiguration>(_ => novuConfiguration);
    }


    public static IServiceCollection RegisterNovuClient(
        this IServiceCollection services,
        IConfiguration configuration,
        RefitSettings refitSettings = null)
    {
        return services
            .AddTransient<INovuClient>(_ => new NovuClient(
                configuration.GetNovuClientConfiguration(),
                refitSettings: RefitSettings(refitSettings)));
    }
    
    private static RefitSettings RefitSettings(RefitSettings refitSettings)
    {
        return refitSettings ?? new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(NovuJsonSettings.DefaultSerializerSettings),
        };
    }
}