using Novu.DTO.WorkflowGroup;
using Refit;

namespace Novu.Interfaces;

public interface IWorkflowGroupClient
{
    /// <summary>
    ///     Create a Workflow Group
    /// </summary>
    /// <param name="requestBody"></param>
    /// <returns>
    ///     <see cref="WorkflowGroupSingleResponseDto" /> - The created workflow group
    /// </returns>
    [Post("/notification-groups")]
    public Task<WorkflowGroupSingleResponseDto> CreateWorkflowGroup([Body] WorkflowGroupDto requestBody);

    /// <summary>
    ///     Get All Workflow Groups
    /// </summary>
    /// <returns>
    ///     <see cref="WorkflowGroupBulkResponseDto" /> - List of workflow groups
    /// </returns>
    [Get("/notification-groups")]
    public Task<WorkflowGroupBulkResponseDto> GetWorkflowGroups();

    [Delete("/notification-groups/{id}")]
    public Task DeleteWorkflowGroupAsync(string id);
}