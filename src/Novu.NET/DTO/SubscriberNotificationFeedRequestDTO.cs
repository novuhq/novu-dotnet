using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class SubscriberNotificationFeedRequestDTO
{
    public string SubscriberId { get; set; }
    
    public int Page { get; set; }
    
    public string FeedIdentifier { get; set; }
    
    public bool Seen { get; set; }
}