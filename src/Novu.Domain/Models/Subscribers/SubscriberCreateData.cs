using Newtonsoft.Json;
using Novu.Domain.JsonConverters;

namespace Novu.Domain.Models.Subscribers;

public class SubscriberCreateData
{
    [JsonProperty("subscriberId")] public string SubscriberId { get; set; }

    [JsonProperty("email")] public string? Email { get; set; }

    [JsonProperty("firstName")] public string? FirstName { get; set; }

    [JsonProperty("lastName")] public string? LastName { get; set; }

    [JsonProperty("phone")] public string? Phone { get; set; }

    [JsonProperty("avatar")] public string? Avatar { get; set; }

    [JsonProperty("locale")] public string? Locale { get; set; }

    [JsonProperty("data")]
    [JsonConverter(typeof(DataToObjectConverter))]
    public List<AdditionalData> Data { get; set; } = new();
}