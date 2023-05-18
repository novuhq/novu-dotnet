using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Novu.DTO;
using Refit;

namespace Novu.Interfaces;

public record PreferenceSettings(
    bool Email,
    bool Sms,
    bool Chat,
    bool Push,
    [property: JsonProperty("in_app")] bool InApp);
public record Child(string Field,
    string Value,
    string Operator,
    string On);

public record Filter(
    bool IsNegated,
    string Type,
    string Value,
    Child[] Children);

public record Variable(string Name);
public record Trigger(
    string Type,
    string Identifier,
    Variable[] Variables,
    Variable[] SubscriberVariables);

public record NotificationGroup(
    [property: JsonProperty("_id")] string Id,
    [property: JsonProperty("_organizationId")] string OrganizationId,
    [property: JsonProperty("_environmentId")] string EnvironmentId,
    [property: JsonProperty("_parentId")] string ParentId,
    string Name);
public record Step(
    [property: JsonProperty("_id")]string Id,
    string Name,
    [property: JsonProperty("_templateId")]string TemplateId,
    bool Active,
    bool ShouldStopOnFail,
    object Template,
    Filter[] Filters,
    [property: JsonProperty("_parentId")]JObject ParentId,
    JObject Metadata,
    JObject ReplyCallback); // TODO: Metadata is a JObject, but it can be anything. Need to figure out how to handle this.
public record NotificationTemplate(
    [property: JsonProperty("_id")]string Id,
    [property: JsonProperty("_organizationId")]string OrganizationId,
    [property: JsonProperty("_creatorId")]string CreatorId,
    [property: JsonProperty("_environmentId")]string EnvironmentId,
    [property: JsonProperty("_notificationGroupId")] string NotificationGroupId,
    [property: JsonProperty("_parentId")] string ParentId,
    string Name,
    string Description,
    bool Active,
    bool Draft,
    bool Critical,
    string[] Tags,
    PreferenceSettings PreferenceSettings,
    Step[] Steps,
    Trigger[] Triggers,
    bool Deleted,
    DateTime DeletedAt,
    string DeletedBy,
    NotificationGroup NotificationGroup);

public record UpdateTemplateStatusRequest(bool Active);
public record NovuResponse<T>(T Data);
public interface INotificationTemplatesClient
{
    [Get("/notification-templates")]
    public Task<PaginatedResponseDto<NotificationTemplate>> GetTemplates([Query] int page = 0, [Query] int limit = 10);

    [Delete("/notification-templates/{templateId}")]
    public Task DeleteTemplate(string templateId);
    [Get("/notification-templates/{templateId}")]
    public Task<NovuResponse<NotificationTemplate>> GetTemplate(string templateId);

    [Put("/notification-templates/{templateId}/status")]
    public Task<NovuResponse<NotificationTemplate>> UpdateStatus(string templateId, [Body]UpdateTemplateStatusRequest request);
}