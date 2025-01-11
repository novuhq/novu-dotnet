using Newtonsoft.Json;

namespace Novu.Domain.Models.Events;

public record EventTo
{
    /// <summary>
    ///     Subscriber ID to send the event to.
    /// </summary>
    [JsonProperty("subscriberId")]
    public string SubscriberId { get; set; }

    /// <summary>
    ///     Subscriber email to be populated in workflows.
    /// </summary>
    [JsonProperty("email", Required = Required.AllowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Email { get; set; }

    /// <summary>
    ///     Subscriber phone to be populated in workflows.
    /// </summary>
    [JsonProperty("phone", Required = Required.AllowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Phone { get; set; }
}