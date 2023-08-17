using Newtonsoft.Json;

namespace Novu.Models.Notifications;

public class Subscriber
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("firstName")] public string FirstName { get; set; }

    [JsonProperty("lastName")] public string LastName { get; set; }

    [JsonProperty("phone")] public string Phone { get; set; }

    [JsonProperty("subscriberId")] public string SubscriberId { get; set; }

    [JsonProperty("email")] public string Email { get; set; }
}