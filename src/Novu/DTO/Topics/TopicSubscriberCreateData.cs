namespace Novu.DTO.Topics;

/// <summary>
///     List of subscribers to be added or removed from the Topic.
/// </summary>
public record TopicSubscriberCreateData(List<string> Subscribers)
{
    public List<string> Subscribers { get; set; } = Subscribers;
}