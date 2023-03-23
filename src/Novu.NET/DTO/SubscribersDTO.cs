using Newtonsoft.Json;

namespace Novu.NET.DTO;

public class SubscribersDTO
{
    [JsonProperty("page")]
    public int Page { get; set; }
    
    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }
    
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }
    
    [JsonProperty("data")]
    public SubscriberDTO[] Data { get; set; }
}