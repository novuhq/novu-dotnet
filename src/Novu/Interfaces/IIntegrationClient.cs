using Novu.DTO;
using Novu.DTO.Integrations;
using Refit;

namespace Novu.Interfaces;

/// <summary>
///     see https://docs.novu.co/api/integration-creation/
/// </summary>
public interface IIntegrationClient
{
    /// <summary>
    ///     Return all the integrations the user has created for that organization. Review v.0.17.0 changelog
    ///     for a breaking change
    ///     see https://docs.novu.co/api/get-integrations/
    /// </summary>
    [Get("/integrations")]
    public Task<NovuResponse<IEnumerable<Integration>>> Get();

    /// <summary>
    ///     Get a integration by its ID
    ///     see https://docs.novu.co/api/get-integration/
    /// </summary>
    [Get("/integrations/{id}")]
    public Task<NovuResponse<Integration>> Get(string id);

    /// <summary>
    ///     Return all the active integrations the user has created for that organization. Review v.0.17.0 changelog for a
    ///     breaking change
    ///     see https://docs.novu.co/api/get-active-integrations/
    /// </summary>
    /// <returns></returns>
    [Get("/integrations/active")]
    public Task<NovuResponse<IEnumerable<Integration>>> GetActive();

    /// <summary>
    ///     Create an integration for the current environment the user is based on the API key provided
    ///     https://docs.novu.co/api/create-integration/
    /// </summary>
    [Post("/integrations")]
    public Task<NovuResponse<Integration>> Create([Body] IntegrationCreateData createIntegrationData);

    /// <summary>
    ///     Update the name, content and variables of a integration. Also change it to be default or no.
    ///     see https://docs.novu.co/api/update-integration/
    /// </summary>
    [Put("/integrations/{id}")]
    public Task<NovuResponse<Integration>> Update(
        string id,
        [Body] IntegrationEditData request);

    /// <summary>
    ///     Execute a soft delete of a integration given a certain ID.
    ///     see https://docs.novu.co/api/delete-integration/
    /// </summary>
    [Delete("/integrations/{id}")]
    public Task Delete(string id);

    /// <summary>
    ///     Return the status of the webhook for this provider, if it is supported or if it is not based on a boolean value
    ///     https://docs.novu.co/api/get-webhook-support-status-for-provider/
    /// </summary>
    [Get("/integrations/webhook/provider/{id}/status")]
    public Task GetWebHookSupportStatus(string id);
}