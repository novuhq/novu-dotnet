using Novu.DTO;
using Novu.DTO.Topics;

namespace Novu.Interfaces;

public interface ITopicClient
{
    /// <summary>
    /// Create a topic
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<TopicCreateResponseDto> CreateTopicAsync(TopicCreateDto dto);
    
    /// <summary>
    /// Returns a list of topics that can be paginated using the `page` query parameter. Default page is 0.
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public Task<PaginatedResponseDto<TopicDto>> GetTopicsAsync(int page = 0);
    
    /// <summary>
    /// Get a topic by key
    /// </summary>
    /// <param name="topicKey"></param>
    /// <returns></returns>
    public Task<TopicResponseDto> GetTopicAsync(string topicKey);
    
    /// <summary>
    /// Add subscribers to a topic by key
    /// </summary>
    /// <param name="topicKey"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<TopicSubscriberAdditionResponseDto> 
        AddSubscriberAsync(string topicKey, TopicSubscriberUpdateDto dto);
    
    /// <summary>
    /// Check if a subscriber belongs to a certain topic
    /// </summary>
    /// <example>
    /// <code>
    ///     var subscriber = await client.Topic.VerifySubscriberAsync("topic-key", "subscriber-key");
    ///     Console.WriteLine(subscriber.SubscriberId);
    /// </code>
    /// </example>
    /// <param name="topicKey">Topic Key</param>
    /// <param name="subscriberId">Subscriber ID</param>
    /// <returns></returns>
    public Task<TopicSubscriberDto> VerifySubscriberAsync(string topicKey, string subscriberId);
    
    /// <summary>
    /// Remove a subscriber from a topic
    /// </summary>
    /// <param name="topicKey"></param>
    /// <param name="subscriberKey"></param>
    /// <returns></returns>
    public Task RemoveSubscriberAsync(string topicKey, TopicSubscriberUpdateDto subscriberKey);
    
    /// <summary>
    /// Delete a topic by key
    /// </summary>
    /// <param name="topicKey"></param>
    /// <returns></returns>
    public Task DeleteTopicAsync(string topicKey);
    
    /// <summary>
    /// Rename a topic
    /// </summary>
    /// <param name="topicKey">Topic to be renamed</param>
    /// <param name="newTopicName">New topic name</param>
    /// <returns></returns>
    public Task<TopicResponseDto> RenameTopicAsync(string topicKey, string newTopicName);
}