using Novu.Domain.Models;
using Novu.Domain.Models.Organizations;
using Refit;

namespace Novu.Clients;

public interface IOrganizationMemberClient
{
  
    /// <summary>Remove a member from organization using memberId</summary>
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
    [Delete("/organizations/members/{memberId}")]
    Task<NovuResponse<Member>> Delete(string memberId);

    /// <summary>Fetch all members of current organizations</summary>
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
    [Get("/organizations/members")]
    Task<NovuResponse<IEnumerable<Member>>> Get();
  
}