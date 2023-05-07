namespace Novu.Interfaces
{
    public interface INovuClient
    {
        ISubscriberClient Subscriber { get; }

        IEventClient Event { get; }

        ITopicClient Topic { get; }
    }   
}