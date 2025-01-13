using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step.Message;

public class MessageCtaData
{
    [JsonProperty("url")] public Uri Url { get; set; }
}