using Novu.Clients;
using Novu.Interfaces;
using Refit;

namespace Novu;

public class NovuClient : INovuClient
{
    public NovuClient(INovuClientConfiguration configuration): this(configuration, default) {}

    public NovuClient(INovuClientConfiguration configuration,HttpClient? client = default)
    {
        var httpClient = client ?? new HttpClient();
        httpClient.BaseAddress = new Uri(configuration.Url);
        httpClient.DefaultRequestHeaders.Add("Authorization", $"ApiKey {configuration.ApiKey}");
        Subscriber = RestService.For<ISubscriberClient>(httpClient);
        Event = RestService.For<IEventClient>(httpClient);
        Topic = RestService.For<ITopicClient>(httpClient);
    }

    public ISubscriberClient Subscriber { get; }
    
    public IEventClient Event { get; }
    
    public ITopicClient Topic { get; }
}