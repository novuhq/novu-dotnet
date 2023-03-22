using Newtonsoft.Json;
using Novu.NET.Models;

namespace Novu.NET.DTO;

public class PaginatedResponseBaseDTO<T>
{
    [JsonProperty("page")]
    public int Page { get; set; }
    
    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }
    
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }
    
    [JsonProperty("data")]
    public PaginatedData<T> Data { get; set; }
}