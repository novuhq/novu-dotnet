using Novu.Domain.Models;
using Novu.Domain.Models.Environments;
using Refit;

namespace Novu.Clients;

public interface IEnvironmentClient
{
    /// <summary>Get current environment</summary>
    /// <returns>Ok</returns>
    /// <exception cref="ApiException">
    ///     Thrown when the request returns a non-success status code:
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Status</term>
    ///             <description>Description</description>
    ///         </listheader>
    ///         <item>
    ///             <term>409</term>
    ///             <description>
    ///                 The request could not be completed due to a conflict with the current state of the target
    ///                 resource.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>429</term>
    ///             <description>The client has sent too many requests in a given amount of time. </description>
    ///         </item>
    ///         <item>
    ///             <term>503</term>
    ///             <description>
    ///                 The server is currently unable to handle the request due to a temporary overload or scheduled
    ///                 maintenance, which will likely be alleviated after some delay.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </exception>
    [Headers("Accept: application/json")]
    [Get("/environments/me")]
    Task<NovuResponse<NovuEnvironment>> Me();

    /// <summary>Get environments</summary>
    /// <returns>Ok</returns>
    /// <exception cref="ApiException">
    ///     Thrown when the request returns a non-success status code:
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Status</term>
    ///             <description>Description</description>
    ///         </listheader>
    ///         <item>
    ///             <term>409</term>
    ///             <description>
    ///                 The request could not be completed due to a conflict with the current state of the target
    ///                 resource.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>429</term>
    ///             <description>The client has sent too many requests in a given amount of time. </description>
    ///         </item>
    ///         <item>
    ///             <term>503</term>
    ///             <description>
    ///                 The server is currently unable to handle the request due to a temporary overload or scheduled
    ///                 maintenance, which will likely be alleviated after some delay.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </exception>
    [Headers("Accept: application/json")]
    [Get("/environments")]
    Task<NovuPaginatedResponse<NovuEnvironment>> Get();

    /// <summary>Get api keys</summary>
    /// <returns>Ok</returns>
    /// <exception cref="ApiException">
    ///     Thrown when the request returns a non-success status code:
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Status</term>
    ///             <description>Description</description>
    ///         </listheader>
    ///         <item>
    ///             <term>409</term>
    ///             <description>
    ///                 The request could not be completed due to a conflict with the current state of the target
    ///                 resource.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>429</term>
    ///             <description>The client has sent too many requests in a given amount of time. </description>
    ///         </item>
    ///         <item>
    ///             <term>503</term>
    ///             <description>
    ///                 The server is currently unable to handle the request due to a temporary overload or scheduled
    ///                 maintenance, which will likely be alleviated after some delay.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </exception>
    [Headers("Accept: application/json")]
    [Get("/environments/api-keys")]
    Task<NovuResponse<IEnumerable<ApiKey>>> ApiKeys();

    /// <summary>Regenerate api keys</summary>
    /// <returns>Created</returns>
    /// <exception cref="ApiException">
    ///     Thrown when the request returns a non-success status code:
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Status</term>
    ///             <description>Description</description>
    ///         </listheader>
    ///         <item>
    ///             <term>409</term>
    ///             <description>
    ///                 The request could not be completed due to a conflict with the current state of the target
    ///                 resource.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>429</term>
    ///             <description>The client has sent too many requests in a given amount of time. </description>
    ///         </item>
    ///         <item>
    ///             <term>503</term>
    ///             <description>
    ///                 The server is currently unable to handle the request due to a temporary overload or scheduled
    ///                 maintenance, which will likely be alleviated after some delay.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </exception>
    [Headers("Accept: application/json")]
    [Post("/environments/api-keys/regenerate")]
    Task<NovuResponse<IEnumerable<ApiKey>>> Regenerate();
}