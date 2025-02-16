using System;
using System.Net.Http;
using System.Reflection;
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
        RefitSettings refitSettings = null,
        Action<HttpClient> configureHttpClient = null)
    {
        var novuConfiguration = configuration.GetNovuClientConfiguration();
        var configureClient = configureHttpClient ?? ConfigureClient(novuConfiguration);
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
        services.AddRefitClient<IBlueprintClient>(settings).ConfigureHttpClient(configureClient);

        return services
            .AddTransient<INovuClientConfiguration>(_ => novuConfiguration);
    }


    /// <summary>
    ///     Configures an <see cref="HttpClient" /> with the necessary headers for Novu API communication.
    /// </summary>
    /// <remarks>
    ///     Hand this into the configuration with includeUserAgent as false to turn off
    /// </remarks>
    /// <param name="novuConfiguration">The configuration containing the Novu API base URL and API key.</param>
    /// <param name="includeUserAgent">Indicates whether to include a custom User-Agent header. Default is true.</param>
    /// <returns>
    ///     An <see cref="Action{HttpClient}" /> that applies the necessary configuration to an <see cref="HttpClient" />
    ///     instance.
    /// </returns>
    public static Action<HttpClient> ConfigureClient(
        NovuClientConfiguration novuConfiguration,
        bool includeUserAgent = true)
    {
        return client =>
        {
            // Set the base address for API requests
            client.BaseAddress = new Uri(novuConfiguration.Url);

            // Ensure only one Authorization header exists
            if (client.DefaultRequestHeaders.Contains("Authorization"))
            {
                client.DefaultRequestHeaders.Remove("Authorization");
            }

            client.DefaultRequestHeaders.Add("Authorization", $"ApiKey {novuConfiguration.ApiKey}");
            if (includeUserAgent)
            {
                var userAgent = NovuConstants.UserAgent();
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);
            }
        };
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