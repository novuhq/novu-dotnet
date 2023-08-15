using Newtonsoft.Json;

namespace Novu.Models.Workflows.Step.Message;

public abstract class BaseMessageTemplate
{
    [JsonProperty("deleted")] public bool Deleted { get; set; }
    [JsonProperty("variables")] public TemplateVariable[] Variables { get; set; }
    [JsonProperty("actor")] public Actor Actor { get; set; }
}