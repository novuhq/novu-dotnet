using Novu.DTO;
using Novu.DTO.Messages;
using Novu.Models.Notifications;
using Refit;

namespace Novu.Interfaces;

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