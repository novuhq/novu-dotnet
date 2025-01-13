using Newtonsoft.Json;

namespace Novu.Domain.Models;

/// <summary>
///     see NovuPaginatedResponse
/// </summary>
/// <typeparam name="T"></typeparam>
public class NovuPaginatedResponse<T>
{
    /// <summary>
    ///     The current page of the paginated response (ordinal, zero indexed)
    /// </summary>
    [JsonProperty("page")]
    public int Page { get; set; }

    /// <summary>
    ///     Number of items on each page
    /// </summary>
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }

    /// <summary>
    ///     Does the list have more items to fetch? Another set based on <see cref="Page" /> and greater than zero
    ///     <see cref="PageSize" />
    ///     can be requested
    /// </summary>
    [JsonProperty("hasMore")]
    public bool HasMore { get; set; }

    /// <summary>
    ///     Many paginated responses DO NOT return this value
    /// </summary>
    /// <remarks>
    ///     <see cref="ISubscriberClient.GetInApp" />
    /// </remarks>
    [JsonProperty("totalCount")]
    public int? TotalCount { get; set; }

    /// <summary>
    ///     The list of items matching the query
    /// </summary>
    [JsonProperty("data")]
    public T[] Data { get; set; }
}