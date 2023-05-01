using Newtonsoft.Json;

namespace Novu.DTO;

public class SubscribersDto
{
    [JsonProperty("page")]
    public int Page { get; set; }
    
    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }
    
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }
    
    [JsonProperty("data")]
    public SubscriberDto[] Data { get; set; }
}