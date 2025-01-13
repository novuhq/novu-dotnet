using Newtonsoft.Json;

namespace Novu.Domain.Models.Integrations;

/// <summary>
///     This object has ALL the options across ALL providers in various combinations
/// </summary>
/// <remarks>
///     When serialised an empty credentials has no properties by design so that each provider only gets
///     details that it requires
/// </remarks>
public class Credentials
{
    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    [JsonProperty("user")]
    public string User { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    [JsonProperty("password")]
    public string Password { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    /// <remarks>
    ///     Custom Email: DKIM: Domain name
    /// </remarks>
    [JsonProperty("domain")] public string Domain { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    [JsonProperty("host")]
    public string Host { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    [JsonProperty("port")]
    public string Port { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    [JsonProperty("secure", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Secure { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    [JsonProperty("requireTls", NullValueHandling = NullValueHandling.Ignore)]
    public bool? RequireTls { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    [JsonProperty("ignoreTls", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IgnoreTls { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    ///         - ses
    /// </summary>
    [JsonProperty("from")]
    public string From { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    ///         - ses
    /// </summary>
    [JsonProperty("senderName")]
    public string SenderName { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - ses
    ///         - sns
    /// </summary>
    [JsonProperty("apiKey")]
    public string ApiKey { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - ses
    ///         - sns
    ///         - nodemailer
    /// </summary>
    /// <remarks>
    ///     Custom Email: DKIM: Private key
    /// </remarks>   [JsonProperty("secretKey")]
    public string SecretKey { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - ses
    ///         - sns
    /// </summary>
    [JsonProperty("region")]
    public string Region { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - nodemailer
    /// </summary>
    /// <remarks>
    ///     Custom Email: DKIM: Key selector
    /// </remarks>
    [JsonProperty("accountSid")] public string AccountSid { get; set; }
    [JsonProperty("messageProfileId")] public string MessageProfileId { get; set; }
    [JsonProperty("token")] public string Token { get; set; }
    [JsonProperty("projectName")] public string ProjectName { get; set; }
    [JsonProperty("applicationId")] public string ApplicationId { get; set; }
    [JsonProperty("clientId")] public string ClientId { get; set; }
    [JsonProperty("tlsOptions")] public string TlsOptions { get; set; }
    [JsonProperty("baseUrl")] public string BaseUrl { get; set; }
    [JsonProperty("webhookUrl")] public string WebhookUrl { get; set; }
    [JsonProperty("redirectUrl")] public string RedirectUrl { get; set; }

    /// <summary>
    ///     Providers used:
    ///         - novu
    /// </summary>
    [JsonProperty("hmac", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Hmac { get; set; }

    [JsonProperty("serviceAccount")] public string ServiceAccount { get; set; }
    [JsonProperty("ipPoolName")] public string IpPoolName { get; set; }
}