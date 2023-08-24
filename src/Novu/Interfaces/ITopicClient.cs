using Novu.DTO;
using Novu.DTO.Topics;
using Refit;

namespace Novu.Interfaces;

public interface ITopicClient
{
    /// <summary>
    ///     <para>
    ///         Returns a list of topics that can be paginated using the `page` query parameter.
    ///         Default page is 0 and counts on zero-based indexing.
    ///     </para>
    ///     <example>
    ///         <code>
    ///         // Specify page in request
    ///         var topics = await client.Topic.GetTopicsAsync(1);
    /// 
    ///         // Get the first page
    ///         var topics = await client.Topic.GetTopicsAsync();
    ///     </code>
    ///     </example>
    /// </summary>
    /// <param name="page">
    ///     Page number - zero-based indexing (<see cref="int" />)
    /// </param>
    /// <returns>
    ///     Returns a <see cref="NovuPaginatedResponse{T}" /> of type <see cref="Topic" />
    /// </returns>
    [Get("/topics")]
    public Task<NovuPaginatedResponse<Topic>> Get([Query] int page = 0);

    /// <summary>
    ///     Create a topic
    /// </summary>
    /// <example>
    ///     <para>
    ///         <code>
    /// var topicRequest = new TopicCreateDto
    /// {
    ///     Key = $"test:topic:{Guid.NewGuid().ToString()}",
    ///     Name = "Test Topic",
    /// };
    /// 
    /// var topic = await client.Topic.CreateTopicAsync(topicRequest);
    /// </code>
    ///     </para>
    /// </example>
    [Post("/topics")]
    public Task<NovuResponse<Topic>> Create([Body] TopicCreateData data);

    /// <summary>
    ///     <para>
    ///         Get a topic by passing in a specified key.
    ///     </para>
    ///     <example>
    ///         <code>
    ///             var topic = await client.Topic.GetTopicAsync("topic-key");
    ///         </code>
    ///     </example>
    /// </summary>
    /// <param name="topicKey">
    ///     Topic Key (<see cref="string" />)
    /// </param>
    /// <returns></returns>
    [Get("/topics/{topicKey}")]
    public Task<NovuResponse<Topic>> Get(string topicKey);

    /// <summary>
    ///     Add an array of subscribers to a topic.
    /// </summary>
    /// <example>
    ///     <code>
    ///     var subscriberList = new TopicSubscriberUpdateDto
    ///     {
    ///         Keys = new <see cref="List{String}" />
    ///         {
    ///             "test:subscriber:1",
    ///         }
    ///     };
    /// 
    ///     var result = await client.Topic.AddSubscriberAsync("topic-key", subscriberList);
    /// 
    /// </code>
    /// </example>
    [Post("/topics/{topicKey}/subscribers")]
    public Task<NovuResponse<SucceedData>> AddSubscriber(string topicKey, TopicSubscriberCreateData data);

    /// <summary>
    ///     Check if a subscriber belongs to a certain topic
    /// </summary>
    /// <example>
    ///     <code>
    ///     var subscriber = await client.Topic.VerifySubscriberAsync("topic-key", "subscriber-key");
    ///     Console.WriteLine(subscriber.SubscriberId);
    /// </code>
    /// </example>
    /// <param name="topicKey">Topic Key</param>
    /// <param name="subscriberId">Subscriber ID</param>
    /// <returns></returns>
    [Get("/topics/{topicKey}/subscribers/{subscriberId}")]
    public Task<NovuResponse<TopicSubscriber>> Verify(string topicKey, string subscriberId);

    /// <summary>
    ///     Remove a subscriber from a topic
    /// </summary>
    /// <example>
    ///     <code>
    ///     var subscriberList = new TopicSubscriberUpdateDto
    ///     {
    ///         Keys = new <see cref="List{String}" />
    ///         {
    ///             "test:subscriber:1",
    ///         }
    ///     };
    /// 
    ///     var result = await client.Topic.RemoveSubscriberAsync("topic-key", subscriberList);
    /// 
    /// </code>
    /// </example>
    /// <param name="topicKey"></param>
    /// <param name="subscriberKey"></param>
    /// <returns></returns>
    [Post("/topics/{topicKey}/subscribers/removal")]
    public Task RemoveSubscriber(string topicKey, [Body] TopicSubscriberCreateData subscriberKey);

    /// <summary>
    ///     Delete a topic by key
    /// </summary>
    /// <example>
    ///     <code>
    ///         await client.Topic.DeleteTopicAsync("topic-key");
    ///     </code>
    /// </example>
    /// <param name="topicKey">
    ///     Topic Key to delete (<see cref="string" />)
    /// </param>
    /// <returns></returns>
    [Delete("/topics/{topicKey}")]
    public Task Delete(string topicKey);

    /// <summary>
    ///     Rename a topic
    /// </summary>
    /// <example>
    ///     <code>
    ///         var topic = await client.Topic.RenameTopicAsync("topic-key", "new-topic-name");
    ///     </code>
    /// </example>
    [Patch("/topics/{topicKey}")]
    public Task<NovuResponse<Topic>> Rename(string topicKey, [Body] TopicEditData data);
}