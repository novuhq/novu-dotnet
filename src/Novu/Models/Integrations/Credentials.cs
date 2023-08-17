using Newtonsoft.Json;

namespace Novu.Models.Integrations;

public class Credentials
{
    [JsonProperty("user")] public string User { get; set; }
    [JsonProperty("password")] public string Password { get; set; }
    [JsonProperty("domain")] public string Domain { get; set; }
    [JsonProperty("host")] public string Host { get; set; }
    [JsonProperty("port")] public string Port { get; set; }
    [JsonProperty("secure")] public bool Secure { get; set; }
    [JsonProperty("requireTls")] public bool RequireTls { get; set; }
    [JsonProperty("ignoreTls")] public bool IgnoreTls { get; set; }
    [JsonProperty("from")] public string From { get; set; }
    [JsonProperty("senderName")] public string SenderName { get; set; }
    [JsonProperty("apiKey")] public string ApiKey { get; set; }
    [JsonProperty("secretKey")] public string SecretKey { get; set; }
    [JsonProperty("region")] public string Region { get; set; }
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
    [JsonProperty("hmac")] public bool Hmac { get; set; }
    [JsonProperty("serviceAccount")] public string ServiceAccount { get; set; }
    [JsonProperty("ipPoolName")] public string IpPoolName { get; set; }
}