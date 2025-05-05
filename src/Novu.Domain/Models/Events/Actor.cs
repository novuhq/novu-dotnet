using Newtonsoft.Json;

namespace Novu.Domain.Models.Events;

/// <summary>
///     Represents an actor, either a string subscriber ID or a detailed subscriber object.
///     If a new actor object is provided, a new subscriber will be created in the system.
///     <remarks>
///         Using only the <see cref="SubscriberId" /> is equivalent to using <see cref="EventData.Actor" /> in the
///         stringly form.
///     </remarks>
/// </summary>
public class Actor
{
    /// <summary>
    ///     The internal identifier you used to create this subscriber, usually correlates to the user ID in your systems.
    /// </summary>
    [JsonProperty("subscriberId", Required = Required.Always)]
    public string SubscriberId { get; set; }

    /// <summary>
    ///     The email address of the subscriber.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    ///     The first name of the subscriber.
    /// </summary>
    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    /// <summary>
    ///     The last name of the subscriber.
    /// </summary>
    [JsonProperty("lastName")]
    public string LastName { get; set; }

    /// <summary>
    ///     The phone number of the subscriber.
    /// </summary>
    [JsonProperty("phone")]
    public string Phone { get; set; }

    /// <summary>
    ///     An HTTP URL to the profile image of your subscriber.
    /// </summary>
    [JsonProperty("avatar")]
    public string Avatar { get; set; }

    /// <summary>
    ///     The locale of the subscriber.
    /// </summary>
    [JsonProperty("locale")]
    public string Locale { get; set; }

    /// <summary>
    ///     An optional payload object that can contain any custom properties.
    /// </summary>
    [JsonProperty("data")]
    public Dictionary<string, object> Data { get; set; }

    /// <summary>
    ///     An optional array of subscriber channels.
    /// </summary>
    [JsonProperty("channels")]
    public List<Dictionary<string, object>> Channels { get; set; }

    /// <summary>
    ///     The timezone of the subscriber.
    /// </summary>
    [JsonProperty("timezone")]
    public string Timezone { get; set; }
}