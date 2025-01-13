using Novu.Domain.Models;
using Novu.Domain.Models.Notifications;
using Refit;

namespace Novu.Clients;

public interface IExecutionDetailsClient
{
    /// <summary>
    ///     see https://docs.novu.co/api/get-execution-details/
    /// </summary>
    /// <param name="notificationId"></param>
    /// <param name="subscriberId"></param>
    /// <returns></returns>
    [Get("/execution-details")]
    public Task<NovuResponse<ExecutionDetail[]>> Get([Query] string notificationId, [Query] string subscriberId);
}