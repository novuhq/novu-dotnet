using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Novu.NotificationTemplates;

public class PreferenceSettings
{
    [JsonProperty("email")]
    public bool Email { get; set; }
    
    [JsonProperty("sms")]
    public bool Sms { get; set; }
    
    [JsonProperty("chat")]
    public bool Chat { get; set; }
    
    [JsonProperty("push")]
    public bool Push { get; set; }
    
    [JsonProperty("in_app")]
    public bool InApp { get; set; }
}

public class Child
{
    [JsonProperty("field")]
    public string Field { get; set; }
    
    [JsonProperty("value")]
    public string Value { get; set; }
    
    [JsonProperty("operator")]
    public string Operator { get; set; }
    
    [JsonProperty("on")]
    public string On { get; set; }
}

public class Filter
{
    [JsonProperty("isNegated")]
    public bool IsNegated { get; set; }
    
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("value")]
    public string Value { get; set; }
    
    [JsonProperty("children")]
    public Child[] Children { get; set; }
}

public class Variable
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class Trigger
{
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("identifier")]
    public string Identifier { get; set; }
    
    [JsonProperty("variables")]
    public Variable[] Variables { get; set; }
    
    [JsonProperty("subscriberVariables")]
    public Variable[] SubscriberVariables { get; set; }
}

public class NotificationGroup
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    
    [JsonProperty("_organizationId")]
    public string OrganizationId { get; set; }
    
    [JsonProperty("_environmentId")]
    public string EnvironmentId { get; set; }
    
    [JsonProperty("_parentId")]
    public string ParentId { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class Step
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("_templateId")]
    public string TemplateId { get; set; }
    
    [JsonProperty("active")]
    public bool Active { get; set; }
    
    [JsonProperty("shouldStopOnFail")]
    public bool ShouldStopOnFail { get; set; }
    
    [JsonProperty("template")]
    public object Template { get; set; }

    [JsonProperty("filters")]
    public Filter[] Filters { get; set; }
    
    [JsonProperty("_parentId")]
    public string ParentId { get; set; }
    
    [JsonProperty("metadata")]
    public object Metadata { get; set; }
    
    [JsonProperty("replyCallback")]
    public object ReplyCallback { get; set; }
    
}

public class NotificationTemplate
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    
    [JsonProperty("_organizationId")]
    public string OrganizationId { get; set; }
    
    [JsonProperty("_creatorId")]
    public string CreatorId { get; set; }
    
    [JsonProperty("_environmentId")]
    public string EnvironmentId { get; set; }
    
    [JsonProperty("_notificationGroupId")]
    public string NotificationGroupId { get; set; }
    
    [JsonProperty("_parentId")]
    public string ParentId { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("active")]
    public bool Active { get; set; }
    
    [JsonProperty("draft")]
    public bool Draft { get; set; }
    
    [JsonProperty("critical")]
    public bool Critical { get; set; }
    
    [JsonProperty("tags")]
    public string[] Tags { get; set; }
    
    [JsonProperty("preferenceSettings")]
    public PreferenceSettings PreferenceSettings { get; set; }
    
    [JsonProperty("steps")]
    public Step[] Steps { get; set; }
    
    [JsonProperty("triggers")]
    public Trigger[] Triggers { get; set; }
    
    [JsonProperty("deleted")]
    public bool Deleted { get; set; }
    
    [JsonProperty("deletedAt")]
    public DateTime DeletedAt { get; set; }
    
    [JsonProperty("deletedBy")]
    public string DeletedBy { get; set; }
    
    [JsonProperty("notificationGroup")]
    public NotificationGroup NotificationGroup { get; set; }
}

public class UpdateTemplateStatusRequest
{
    [JsonProperty("active")]
    public bool Active { get; set; }
}