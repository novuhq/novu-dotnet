using Newtonsoft.Json;
using Novu.JsonConverters;
using Novu.Models.Workflows.Step.Message;

namespace Novu.Models.Workflows.Step;

/// <summary>
/// </summary>
/// <remarks>
///     Originally NotificationTemplateStep
/// </remarks>
public class Step
{
    [JsonProperty("_id")] public string Id { get; set; }
    [JsonProperty("uuid")] public string Uuid { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("filters")] public Filter[] Filters { get; set; }
    [JsonProperty("_templateId")] public string TemplateId { get; set; }
    [JsonProperty("_parentId")] public string ParentId { get; set; }

    /// <summary>
    ///     Part 1 main configuration for a step
    /// </summary>
    [JsonProperty("template")]
    [JsonConverter(typeof(MessageTemplateConverter))]
    public IMessageTemplate Template { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }
    [JsonProperty("shouldStopOnFail")] public bool ShouldStopOnFail { get; set; }
    [JsonProperty("replyCallback")] public ReplyCallback ReplyCallback { get; set; }

    /// <summary>
    ///     Part 2 main configuration for a step
    /// </summary>
    [JsonProperty("metadata")]
    [JsonConverter(typeof(MetaDataConverter))]
    public IWorkflowMetaData Metadata { get; set; }
}