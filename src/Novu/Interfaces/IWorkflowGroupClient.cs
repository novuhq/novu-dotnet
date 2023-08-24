using Novu.DTO;
using Novu.DTO.WorkflowGroups;
using Refit;

namespace Novu.Interfaces;

public interface IWorkflowGroupClient
{
    /// <summary>
    ///     Create a Workflow Group
    /// </summary>
    /// <param name="requestBody"></param>
    [Post("/notification-groups")]
    public Task<NovuResponse<WorkflowGroup>> Create([Body] WorkflowGroupCreateData requestBody);

    /// <summary>
    ///     Get All Workflow Groups
    /// </summary>
    [Get("/notification-groups")]
    public Task<NovuResponse<IEnumerable<WorkflowGroup>>> Get();

    [Delete("/notification-groups/{id}")]
    public Task Delete(string id);
}