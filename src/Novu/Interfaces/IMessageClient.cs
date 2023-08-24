using Novu.DTO;
using Novu.DTO.Layouts;
using Novu.DTO.Messages;
using Refit;

namespace Novu.Interfaces;

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
        [Query] string? channel = default,
        [Query] string? subscriberId = default,
        [Query] string? transactionId = default);

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
    public Task<NovuResponse<AcknowledgeData>> Delete(string id);
}