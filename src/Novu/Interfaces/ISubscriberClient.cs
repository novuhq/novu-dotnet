using Novu.DTO;
using Novu.DTO.Notifications;
using Novu.DTO.Subscriber;
using Novu.DTO.Subscriber.Preferences;
using Novu.Exceptions;
using Refit;

namespace Novu.Interfaces;

public interface ISubscriberClient
{
    /// <summary>
    ///     Get a paginated response of current Subscribers
    /// </summary>
    /// <returns></returns>
    /// <exception cref="HttpRequestException">
    ///     Thrown when the status code does not equal 200.
    /// </exception>
    /// <exception cref="NovuClientException"></exception>
    [Get("/subscribers")]
    Task<PaginatedResponseDto<SubscriberDto>> GetSubscribers([Query] int page = 0, int limit = 100);

    /// <summary>
    ///     Get a single Subscriber
    /// </summary>
    /// <param name="id"><see cref="String" /> Subscriber ID</param>
    /// <returns></returns>
    [Get("/subscribers/{id}")]
    Task<NovuResponse<SubscriberDto>> GetSubscriber(string id);

    /// <summary>
    ///     Create a new Subscriber
    /// </summary>
    /// <param name="dto">
    ///     <see cref="CreateSubscriberDto" /> Model to create a new Subscriber
    /// </param>
    /// <returns>
    ///     <see cref="SubscriberDto" /> The newly created Subscriber
    /// </returns>
    [Post("/subscribers")]
    Task<NovuResponse<SubscriberDto>> CreateSubscriber([Body] CreateSubscriberDto dto);

    /// <summary>
    ///     Update a Subscriber
    /// </summary>
    /// <param name="id">
    ///     <see cref="string" /> Subscriber ID to update
    /// </param>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    [Put("/subscribers/{id}")]
    Task<NovuResponse<SubscriberDto>> UpdateSubscriber(string id, [Body] SubscriberDto requestDto);

    /// <summary>
    ///     Delete a Subscriber
    /// </summary>
    /// <param name="id">
    ///     <see cref="string" /> Subscriber ID to delete
    /// </param>
    /// <returns>
    ///     <see cref="DeleteResponseDto" />
    /// </returns>
    [Delete("/subscribers/{id}")]
    Task<DeleteResponseDto> DeleteSubscriber(string id);

    /// <summary>
    ///     Update Subscribers online status
    /// </summary>
    /// <param name="id"><see cref="SubscriberDto.SubscriberId" /> Subscribers ID</param>
    /// <param name="model">
    ///     <see cref="SubscriberOnlineDto" />
    /// </param>
    /// <returns></returns>
    [Patch("/subscribers/{id}/online-status")]
    Task<NovuResponse<SubscriberDto>> UpdateOnlineStatus(string id, [Body] SubscriberOnlineDto model);

    [Get("/subscribers/{id}/preferences")]
    Task<NovuResponse<IEnumerable<SubscriberPreference>>> GetPreferences(string id);

    [Patch("/subscribers/{id}/preferences/{templateId}")]
    Task<NovuResponse<SubscriberPreference>> UpdatePreference(
        string id,
        string templateId,
        [Body] SubscriberPreferenceEditData model);

    [Get("/subscribers/{id}/notifications/feed")]
    Task<PaginatedResponseDto<Notification>> GetInApp(string id, [Query] InAppFeedQueryParams? queryParams = default);

    [Get("/subscribers/{id}/notifications/unseen")]
    Task<NovuResponse<NotificationCount>> GetInAppUnseen(string id);
}