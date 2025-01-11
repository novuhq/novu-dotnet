using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Integrations;

public class IntegrationCreateData
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("identifier")] public string Identifier { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    [Required]
    [JsonProperty("providerId")]
    public string ProviderId { get; set; }

    [Required] [JsonProperty("channel")] public string Channel { get; set; }

    [JsonProperty("credentials")] public Credentials Credentials { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("check")] public bool Check { get; set; }
}