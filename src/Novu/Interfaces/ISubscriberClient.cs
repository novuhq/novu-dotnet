using Novu.DTO;
using Novu.Exceptions;
using Refit;

namespace Novu.Clients;

public interface ISubscriberClient
{
    /// <summary>
    /// Get a paginated response of current Subscribers
    /// </summary>
    /// <returns></returns>
    /// <exception cref="HttpRequestException">
    ///  Thrown when the status code does not equal 200.
    /// </exception>
    /// <exception cref="NovuClientException"></exception>
    [Get("/subscribers")]
    Task<SubscribersDto> GetSubscribers([Query] int page = 0);

    /// <summary>
    /// Get a single Subscriber
    /// </summary>
    /// <param name="id"><see cref="String"/> Subscriber ID</param>
    /// <returns></returns>
    [Get("/subscribers/{id}")]
    Task<SubscriberDto> GetSubscriber(string id);
    /// <summary>
    /// Create a new Subscriber
    /// </summary>
    /// <param name="dto">
    /// <see cref="CreateSubscriberDto"/> Model to create a new Subscriber
    /// </param>
    /// <returns>
    /// <see cref="SubscriberDto"/> The newly created Subscriber
    /// </returns>
    [Post("/subscribers")]
    Task<SubscriberDto> CreateSubscriber([Body]CreateSubscriberDto dto);

    /// <summary>
    /// Update a Subscriber
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    [Put("/subscribers/{id}")]
    Task<SubscriberDto> UpdateSubscriber(string id, [Body]SubscriberDto requestDto);

    /// <summary>
    /// Delete a Subscriber
    /// </summary>
    /// <param name="id">
    /// <see cref="string"/> Subscriber ID to delete
    /// </param>
    /// <returns>
    /// <see cref="DeleteResponseDto"/>
    /// </returns>
    [Delete("/subscribers/{id}")]
    Task<DeleteResponseDto> DeleteSubscriber(string id);
    /// <summary>
    /// Update Subscribers online status
    /// </summary>
    /// <param name="subscriberId"><see cref="SubscriberDto.SubscriberId"/> Subscribers ID</param>
    /// <param name="model"><see cref="SubscriberOnlineDto"/></param>
    /// <returns></returns>
    [Patch("/subscribers/{subscriberId}/online-status")]
    Task<SubscriberDto> UpdateOnlineStatus(string subscriberId, [Body]SubscriberOnlineDto model);
}