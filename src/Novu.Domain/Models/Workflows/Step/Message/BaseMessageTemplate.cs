using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step.Message;

public abstract class BaseMessageTemplate
{
    [JsonProperty("deleted")] public bool Deleted { get; set; }
    [JsonProperty("variables")] public TemplateVariable[] Variables { get; set; }
    [JsonProperty("actor")] public Actor Actor { get; set; }

    /// <summary>
    ///     All messages CAN have a layout although the general approach is to only provide layouts for
    ///     an email as a wrapper around the content of the message
    /// </summary>
    [JsonProperty("layoutId")]
    public string? LayoutId
    {
        get => _layoutId;
        set => _layoutId = value;
    }

    // ReSharper disable once InconsistentNaming
    [JsonProperty("_layoutId")] public string? _layoutId { get; set; }
}