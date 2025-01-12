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
    ///     Subscriber first name to be populated in workflows.
    /// </summary>
    [JsonProperty("firstName", Required = Required.AllowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string FirstName { get; set; }

    /// <summary>
    ///     Subscriber last name to be populated in workflows.
    /// </summary>
    [JsonProperty("lastName", Required = Required.AllowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LastName { get; set; }

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

    /// <summary>
    ///     Subscriber avatar to be populated in workflows.
    /// </summary>
    [JsonProperty("avatar", Required = Required.AllowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Avatar { get; set; }

    /// <summary>
    ///     Subscriber locale to be populated in workflows.
    /// </summary>
    [JsonProperty("locale", Required = Required.AllowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Locale { get; set; }

    /// <summary>
    ///     Set of arbitrary data as a json structure that should be { key:value }
    ///     see https://docs.novu.co/concepts/subscribers#subscriber-attributes
    /// </summary>
    [JsonProperty("data", Required = Required.AllowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public dynamic Data { get; set; }
}