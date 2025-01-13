using Novu.Domain.Models;
using Novu.Domain.Models.Notifications;
using Novu.Domain.Models.Subscribers;
using Novu.Domain.Models.Subscribers.Notifications;
using Novu.Domain.Models.Subscribers.Preferences;
using Novu.QueryParams;
using Refit;
using Subscriber = Novu.Domain.Models.Subscribers.Subscriber;

namespace Novu.Clients;

public interface ISubscriberClient
{
    /// <summary>
    ///     Get a paginated response of current Subscribers
    /// </summary>
    /// <returns></returns>
    /// <exception cref="HttpRequestException">
    ///     Thrown when the status code does not equal 200.
    /// </exception>
    [Get("/subscribers")]
    Task<NovuPaginatedResponse<Subscriber>> Get([Query] int page = 0, int limit = 100);

    [Get("/subscribers")]
    Task<NovuPaginatedResponse<Subscriber>> Get([Query] SubscriberQueryParams? queryParams = default);

    /// <summary>
    ///     Get a single Subscriber
    /// </summary>
    /// <param name="id"><see cref="String" /> Subscriber ID</param>
    /// <returns></returns>
    [Get("/subscribers/{id}")]
    Task<NovuResponse<Subscriber>> Get(string id);

    /// <summary>
    ///     Create a new Subscriber
    /// </summary>
    /// <param name="data">
    ///     <see cref="SubscriberCreateData" /> Model to create a new Subscriber
    /// </param>
    /// <returns>
    ///     <see cref="Subscriber" /> The newly created Subscriber
    /// </returns>
    [Post("/subscribers")]
    Task<NovuResponse<Subscriber>> Create([Body] SubscriberCreateData data);

    /// <summary>
    ///     Update a Subscriber
    /// </summary>
    [Put("/subscribers/{id}")]
    Task<NovuResponse<Subscriber>> Update(string id, [Body] SubscriberEditData data);

    /// <summary>
    ///     Delete a Subscriber
    /// </summary>
    /// <param name="id">
    ///     <see cref="string" /> Subscriber ID to delete
    /// </param>
    [Delete("/subscribers/{id}")]
    Task<NovuResponse<NovuAcknowledgeData>> DeleteSubscriber(string id);

    /// <summary>
    ///     Update Subscribers online status
    /// </summary>
    [Patch("/subscribers/{id}/online-status")]
    Task<NovuResponse<Subscriber>> UpdateOnlineStatus(string id, [Body] SubscriberOnlineEditData data);

    [Get("/subscribers/{id}/preferences")]
    Task<NovuResponse<IEnumerable<SubscriberPreference>>> GetPreferences(string id);

    [Patch("/subscribers/{id}/preferences/{templateId}")]
    Task<NovuResponse<SubscriberPreference>> UpdatePreference(
        string id,
        string templateId,
        [Body] SubscriberPreferenceEditData model);

    [Get("/subscribers/{id}/notifications/feed")]
    Task<NovuPaginatedResponse<Notification>> GetInApp(string id, [Query] InAppFeedQueryParams? queryParams = null);

    [Get("/subscribers/{id}/notifications/unseen")]
    Task<NovuResponse<NotificationCount>> GetInAppUnseen(string id);
}