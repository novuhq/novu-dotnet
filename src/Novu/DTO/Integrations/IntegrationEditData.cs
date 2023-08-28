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

    [JsonProperty("channel")] public string Channel { get; set; }

    /// <summary>
    ///     Flag that is not stored on the resource but rather has the server perform a check that the integration
    ///     can make a connection
    /// </summary>
    [JsonProperty("check")]
    public bool Check { get; set; }
}