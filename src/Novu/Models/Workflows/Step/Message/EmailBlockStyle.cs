using Newtonsoft.Json;

namespace Novu.Models.Workflows.Step.Message;

public class EmailBlockStyle
{
    [JsonProperty("textAlign")] public TextAlignEnum Type { get; set; }
}