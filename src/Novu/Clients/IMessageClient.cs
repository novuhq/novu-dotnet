using Novu.Domain.Models;
using Novu.Domain.Models.Messages;
using Novu.QueryParams;
using Refit;

namespace Novu.Clients;

/// <summary>
///     see https://docs.novu.co/api/get-messages/
/// </summary>
public interface IMessageClient
{
    /// <summary>
    ///     see https://docs.novu.co/api/get-messages/
    /// </summary>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <param name="channel"></param>
    /// <param name="subscriberId"></param>
    /// <param name="transactionId"></param>
    [Get("/messages")]
    public Task<NovuPaginatedResponse<Message>> Get(
        [Query] int page = 0,
        [Query] int limit = 100,
        [Query] string? channel = null,
        [Query] string? subscriberId = null,
        [Query] string? transactionId = null);

    /// <summary>
    ///     see https://docs.novu.co/api/get-messages/
    /// </summary>
    [Get("/messages")]
    public Task<NovuPaginatedResponse<Message>> Get([Query] MessageQueryParams queryParams);

    /// <summary>
    ///     Deletes a message entity from the Novu platform
    ///     see https://docs.novu.co/api/delete-message/
    /// </summary>
    [Delete("/messages/{id}")]
    public Task<NovuResponse<NovuAcknowledgeData>> Delete(string id);
}