using Newtonsoft.Json;

namespace Novu.DTO.Topics;

/// <summary>
/// List of subscribers to be added or removed from the Topic.
/// </summary>
public record TopicSubscriberUpdateDto(List<string> Subscribers)
{
    public List<string> Subscribers { get; set; } = Subscribers;
}