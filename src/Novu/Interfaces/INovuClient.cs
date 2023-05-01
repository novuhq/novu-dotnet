namespace Novu.Interfaces;

public interface INovuClient
{
    public ISubscriberClient Subscriber { get; }
    
    public IEventClient Event { get; }
}