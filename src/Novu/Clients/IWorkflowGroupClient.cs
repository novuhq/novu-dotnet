using Novu.Domain.Models;
using Novu.Domain.Models.WorkflowGroups;
using Refit;

namespace Novu.Clients;

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