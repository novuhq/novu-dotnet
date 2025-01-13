using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step;

public class ReplyCallback
{
    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("url")] public Uri Url { get; set; }
}