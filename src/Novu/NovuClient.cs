using Novu.Clients;
using Novu.Interfaces;

namespace Novu;

public class NovuClient : INovuClient
{
    public NovuClient(INovuClientConfiguration configuration)
    {
        Subscriber = new SubscriberClient(configuration);
        Event = new EventClient(configuration);
    }

    public ISubscriberClient Subscriber { get; }
    
    public IEventClient Event { get; }
}