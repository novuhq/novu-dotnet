using Novu.DTO;
using Novu.DTO.Workflows;
using Refit;

namespace Novu.Interfaces;

public interface IWorkflowClient
{
    /// <summary>
    ///     see https://docs.novu.co/api/get-workflows/
    /// </summary>
    [Get("/workflows")]
    public Task<PaginatedResponseDto<Workflow>> Get([Query] int page = 0, [Query] int limit = 10);

    /// <summary>
    ///     see https://docs.novu.co/api/get-workflow/
    /// </summary>
    [Get("/workflows/{id}")]
    public Task<NovuResponse<Workflow>> Get(string id);

    /// <summary>
    ///     https://docs.novu.co/api/create-workflow/
    /// </summary>
    [Post("/workflows")]
    public Task<NovuResponse<Workflow>> Create([Body] WorkflowCreateData createWorkflowData);

    /// <summary>
    ///     see https://docs.novu.co/api/update-workflow/
    /// </summary>
    [Put("/workflows/{id}")]
    public Task<NovuResponse<Workflow>> Update(
        string id,
        [Body] WorkflowEditData request);

    /// <summary>
    ///     see https://docs.novu.co/api/delete-workflow/
    /// </summary>
    [Delete("/workflows/{id}")]
    public Task<NovuResponse<bool>> Delete(string id);

    /// <summary>
    ///     see https://docs.novu.co/api/update-workflow-status/
    /// </summary>
    [Put("/workflows/{id}/status")]
    public Task<NovuResponse<Workflow>> UpdateStatus(
        string id,
        [Body] WorkflowEditStatusData request);
}