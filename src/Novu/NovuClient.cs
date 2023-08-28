using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Novu.Interfaces;
using Refit;

namespace Novu;

public class NovuClient : INovuClient
{
    public static readonly JsonSerializerSettings DefaultSerializerSettings = new()
    {
        MissingMemberHandling = MissingMemberHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy(),
        },
        // General enum conversions are required to the in-place strings
        Converters = new List<JsonConverter>
        {
            new StringEnumConverter(),
        },
    };

    public NovuClient(
        INovuClientConfiguration configuration,
        HttpClient? client = default,
        RefitSettings? refitSettings = default)
    {
        var httpClient = client ?? new HttpClient();
        httpClient.BaseAddress = new Uri(configuration.Url);
        httpClient.DefaultRequestHeaders.Add("Authorization", $"ApiKey {configuration.ApiKey}");

        refitSettings ??= new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(DefaultSerializerSettings),
        };

        Subscriber = RestService.For<ISubscriberClient>(httpClient, refitSettings);
        Event = RestService.For<IEventClient>(httpClient, refitSettings);
        Topic = RestService.For<ITopicClient>(httpClient, refitSettings);
        WorkflowGroup = RestService.For<IWorkflowGroupClient>(httpClient, refitSettings);
        Workflow = RestService.For<IWorkflowClient>(httpClient, refitSettings);
        Layout = RestService.For<ILayoutClient>(httpClient, refitSettings);
        Integration = RestService.For<IIntegrationClient>(httpClient, refitSettings);
        Notifications = RestService.For<INotificationsClient>(httpClient, refitSettings);
        Message = RestService.For<IMessageClient>(httpClient, refitSettings);
        ExecutionDetails = RestService.For<IExecutionDetailsClient>(httpClient, refitSettings);
    }


    public IWorkflowClient Workflow { get; }
    public ILayoutClient Layout { get; }
    public IIntegrationClient Integration { get; }
    public INotificationsClient Notifications { get; }
    public IMessageClient Message { get; }
    public IExecutionDetailsClient ExecutionDetails { get; }
    public ISubscriberClient Subscriber { get; }
    public IEventClient Event { get; }
    public ITopicClient Topic { get; }
    public IWorkflowGroupClient WorkflowGroup { get; }
}