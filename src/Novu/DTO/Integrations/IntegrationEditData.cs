using Newtonsoft.Json;
using Novu.Models.Integrations;

namespace Novu.DTO.Integrations;

public class IntegrationEditData
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("identifier")] public string Identifier { get; set; }

    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }

    [JsonProperty("credentials")] public Credentials Credentials { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("check")] public bool Check { get; set; }
}