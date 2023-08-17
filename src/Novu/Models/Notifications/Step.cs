using Newtonsoft.Json;

namespace Novu.Models.Notifications;

public class Step
{
    [JsonProperty("metadata")] public Metadata Metadata { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("shouldStopOnFail")] public bool ShouldStopOnFail { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("filters")] public List<object> Filters { get; set; }

    [JsonProperty("_templateId")] public string TemplateId { get; set; }

    [JsonProperty("_parentId")] public object ParentId { get; set; }

    [JsonProperty("_id")] public string Id { get; set; }


    [JsonProperty("template")] public Template Template { get; set; }
}