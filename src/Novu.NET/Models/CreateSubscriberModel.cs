using Newtonsoft.Json;

namespace Novu.NET.Models;

public partial class CreateSubscriberModel
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    [JsonProperty("email")]
    public string? Email { get; set; }
    
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("firstName")]
    public string? LastName { get; set; }
    
    [JsonProperty("phone")]
    public string? Phone { get; set; }
    
    [JsonProperty("avatar")]
    public string? Avatar { get; set; }
    
    [JsonProperty("locale")]
    public string? Locale { get; set; }
    
    [JsonProperty("data")]
    public Dictionary<string, string>? Data { get; set; }
}

public partial class CreateSubscriberModel
{
    public static string ToJson(CreateSubscriberModel self) => JsonConvert.SerializeObject(self, Converter.Settings); 
}