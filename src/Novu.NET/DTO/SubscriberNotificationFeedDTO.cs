namespace Novu.NET.DTO;

public record SubscriberNotificationFeedDTO
{
    public string Id { get; set; }
    
    public string TemplateId { get; set; }
    
    public string EnvironmentId { get; set; }
    
    public string MessageTemplateId { get; set; }
    
    public string OrganizationId { get; set; }
    
    public string NotificationId { get; set; }
    
    public SubscriberDTO Subscriber { get; set; }
    
    public object Template { get; set; }
}