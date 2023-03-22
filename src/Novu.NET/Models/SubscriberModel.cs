using Newtonsoft.Json;

namespace Novu.NET.Models;

public partial class SubscriberModel
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("_organizationId")]
    public string OrganizationId { get; set; }

    [JsonProperty("_environmentId")]
    public string EnvironmentId { get; set; }

    [JsonProperty("subscriberId")]
    public string SubscriberId { get; set; }

    [JsonProperty("channels")]
    public object[] Channels { get; set; }

    [JsonProperty("deleted")]
    public bool Deleted { get; set; }

    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonProperty("__v")]
    public long V { get; set; }

    [JsonProperty("isOnline")]
    public bool IsOnline { get; set; }

    [JsonProperty("lastOnlineAt")]
    public DateTimeOffset LastOnlineAt { get; set; }
}

public partial class SubscriberModel
{
    public static SubscriberModel FromJson(string json) =>
        JsonConvert.DeserializeObject<SubscriberModel>(json, Converter.Settings);
}