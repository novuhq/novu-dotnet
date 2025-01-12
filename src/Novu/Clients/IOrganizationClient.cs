using Novu.Domain.Models;
using Novu.Domain.Models.Organizations;
using Refit;

namespace Novu.Clients;

public interface IOrganizationClient
{
    /// <summary>Create an organization</summary>
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
    [Post("/organizations")]
    Task<NovuResponse<Organization>> Create([Body] OrganizationCreateData body);

    /// <summary>Fetch all organizations</summary>
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
    [Get("/organizations")]
    Task<NovuResponse<IEnumerable<Organization>>> Get();

    /// <summary>Rename organization name</summary>
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
    [Patch("/organizations")]
    Task<NovuResponse<OrganizationNameOnly>> Update([Body] OrganizationEditData data);

    /// <summary>Fetch current organization details</summary>
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
    [Get("/organizations/me")]
    Task<NovuResponse<Organization>> Me();
}