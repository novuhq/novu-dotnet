using Novu.Clients;
using Novu.NotificationTemplates;

namespace Novu.Interfaces;

public interface INovuClient
{
    public ISubscriberClient Subscriber { get; }
    
    public IEventClient Event { get; }
    
    public ITopicClient Topic { get; }
    public INotificationTemplatesClient NotificationTemplates { get; }
    public IWorkflowGroupClient WorkflowGroup { get; }
}