using Newtonsoft.Json;

namespace Novu.Models.Workflows.Step.Message;

public class EmailBlock
{
    [JsonProperty("type")] public EmailBlockTypeEnum Type { get; set; }
    [JsonProperty("content")] public string Content { get; set; }
    [JsonProperty("url")] public Uri Url { get; set; }
    [JsonProperty("styles")] public EmailBlockStyle[] Styles { get; set; }
}