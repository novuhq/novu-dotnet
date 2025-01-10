using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Novu.DTO;
using Novu.Extensions;
using Novu.Sync;
using Novu.Tests.Factories;
using Refit;
using Xunit;

namespace Novu.Tests;

public static class IocModelFactoriesRegistrationExtensions
{
    /// <summary>
    ///     Register all the model factories for tests
    /// </summary>
    public static IServiceCollection RegisterFactories(this IServiceCollection services)
    {
        return services
            .AddTransient<Tracker>()
            // all the factories that manage models in Novu
            .AddTransient<IntegrationFactory>()
            .AddTransient<LayoutFactory>()
            .AddTransient<SubscriberFactory>()
            .AddTransient<TopicFactory>()
            .AddTransient<WorkflowFactory>()
            .AddTransient<WorkflowGroupFactory>()
            // test helpers for injection setup/teardown
            // .AddScoped<BeforeAfterTest, FactorySetupTeardown>()
            // IServiceCollection—this service collection for the ability to swap out for mocks
            .AddScoped(_ => services);
    }

    public static IServiceCollection RegisterNovuClientsWithExceptionHandler(this IServiceCollection services)
    {
        // set environment variable to pickup correct configuration
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Integration");
        var configurationRoot = Settings.FileName.CreateConfigurationRoot();

        var defaultSerializerSettings = NovuClient.DefaultSerializerSettings;

        // setup in-memory logging for
        // see https://www.newtonsoft.com/json/help/html/SerializationTracing.htm
        // TODO: make this more injectable/configurable for ad hoc diagnosis
        var traceWriter = new MemoryTraceWriter();
        defaultSerializerSettings.TraceWriter = traceWriter;

        var refitSettings = new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(defaultSerializerSettings),
            ExceptionFactory = TestExceptionFactory,
        };


        // Reports the client errors up to the tests for diagnosis
        async Task<Exception> TestExceptionFactory(HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                switch (message.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return null;
                }

                var content = await message.Content.ReadAsStringAsync();
                // don't catch any errors because we need to see errors in tests
                try
                {
                    var error = JsonConvert.DeserializeObject<ErrorData>(content);
                    if (error is not null)
                    {
                        // Output.WriteLine("=================================");
                        // Output.WriteLine(traceWriter.ToString());
                        // Output.WriteLine("=================================");
                        Assert.Fail($"[{error.Code}: '{error.Status}'] '{string.Join("; ", error.Message)}'");
                    }
                }
                catch (JsonReaderException e)
                {
                    // Output.WriteLine("=================================");
                    // Output.WriteLine(traceWriter.ToString());
                    // Output.WriteLine("=================================");
                    Assert.Fail($"Cannot convert error message '{e.GetType()}' {content}");
                }
            }

            return null;
        }

        return services
            .RegisterNovuClients(configurationRoot, refitSettings);
    }
}