using Novu.Domain.Models;
using Novu.Domain.Models.Feeds;
using Refit;

namespace Novu.Clients;

public interface IFeedClient
{
    /// <summary>Get feeds</summary>
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
    [Get("/feeds")]
    Task<NovuResponse<IEnumerable<Feed>>> Get();

    /// <summary>Create feed</summary>
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
    [Post("/feeds")]
    Task<NovuResponse<Feed>> Create([Body] FeedCreateData body);

    /// <summary>Delete feed</summary>
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
    [Delete("/feeds/{feedId}")]
    Task Delete(string feedId);
}