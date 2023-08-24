using Newtonsoft.Json;

namespace Novu.NotificationTemplates;

public class Step
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("_templateId")] public string TemplateId { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("shouldStopOnFail")] public bool ShouldStopOnFail { get; set; }

    [JsonProperty("template")] public object Template { get; set; }

    [JsonProperty("filters")] public Filter[] Filters { get; set; }

    [JsonProperty("_parentId")] public string ParentId { get; set; }

    [JsonProperty("metadata")] public object Metadata { get; set; }

    [JsonProperty("replyCallback")] public object ReplyCallback { get; set; }
}