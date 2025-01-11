using System.ComponentModel.DataAnnotations;
using Refit;

namespace Novu.QueryParams;

/// <summary>
///     Base pagination query params for <see cref="NovuPaginatedResponse{T}" />
/// </summary>
public class PaginationQueryParams
{
    /// <summary>
    ///     Default max size of any pagination
    ///     see ?
    /// </summary>
    public const int MaxPageSize = 100;

    [AliasAs("page")] public int Page { get; set; } = 0;

    /// <summary>
    ///     Default max page size <see cref="MaxPageSize" />
    /// </summary>
    [Range(0, 100)]
    [AliasAs("pageSize")]
    public int PageSize { get; set; } = 100;

    /// <summary>
    ///     see ?
    ///     Current only support "createdAt"
    /// </summary>
    [AliasAs("sortBy")]
    public string SortBy { get; set; }

    /// <summary>
    ///     see ?
    ///     Ascending = 1, Descending = -1
    /// </summary>
    [AliasAs("orderBy")]
    public int OrderBy { get; set; }
}