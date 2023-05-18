using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Novu.Clients;
using Novu.Interfaces;
using Refit;

namespace Novu;

public class NovuClient : INovuClient
{
    private static readonly JsonSerializerSettings SerializerSettings = new()
    {
        MissingMemberHandling = MissingMemberHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        }
    };
    public NovuClient(INovuClientConfiguration configuration): this(configuration, default) {}

    public NovuClient(INovuClientConfiguration configuration,HttpClient? client = default)
    {
        var httpClient = client ?? new HttpClient();
        httpClient.BaseAddress = new Uri(configuration.Url);
        httpClient.DefaultRequestHeaders.Add("Authorization", $"ApiKey {configuration.ApiKey}");
        Subscriber = RestService.For<ISubscriberClient>(httpClient, new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(SerializerSettings)
        });
        Event = RestService.For<IEventClient>(httpClient, new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(SerializerSettings)
        });
        Topic = RestService.For<ITopicClient>(httpClient,  new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(SerializerSettings)
        });
        NotificationTemplates = RestService.For<INotificationTemplatesClient>(httpClient, new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(SerializerSettings)
        });
    }

    public ISubscriberClient Subscriber { get; }
    
    public IEventClient Event { get; }
    
    public ITopicClient Topic { get; }
    public INotificationTemplatesClient NotificationTemplates { get; }
}