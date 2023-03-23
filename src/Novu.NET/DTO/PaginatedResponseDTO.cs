using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class PaginatedResponseDTO<T>
{
    [JsonProperty("page")]
    public int Page { get; set; }
    
    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }
    
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }
    
    [JsonProperty("data")]
    public T[] Data { get; set; }
}
