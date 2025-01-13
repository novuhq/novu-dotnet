using Newtonsoft.Json;
using Novu.Domain.Models.Workflows.Step.Message;

namespace Novu.Domain.Models.Layouts;

public class Layout
{
    [JsonProperty("_id")] public string Id { get; set; }
    [JsonProperty("_organizationId")] public string OrganizationId { get; set; }
    [JsonProperty("_environmentId")] public string EnvironmentId { get; set; }
    [JsonProperty("_creatorId")] public string CreatorId { get; set; }


    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("description")] public string Description { get; set; }

    /// <summary>
    ///     Currently looks to be only available for "email"
    /// </summary>
    [JsonProperty("channel")]
    public string Channel { get; set; }

    /// <summary>
    ///     User defined content for the layout. Ensure that variables specified in the content via {{ x }} are
    ///     also included in the <see cref="Variables" />
    /// </summary>
    /// <remarks>
    ///     This content must contain "{{{body}}}" with no spaces
    /// </remarks>
    [JsonProperty("content")]
    public string Content { get; set; }

    /// <summary>
    ///     User defined variables to render in the layout placeholders.
    /// </summary>
    /// <remarks>
    ///     Note: the documentation says it is a string but it isn't.
    /// </remarks>
    [JsonProperty("variables")]
    public TemplateVariable[] Variables { get; set; }

    [JsonProperty("isDefault")] public bool IsDefault { get; set; }
    [JsonProperty("isDeleted")] public bool IsDeleted { get; set; }

    [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }
    [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

    [JsonProperty("_parentId")] public string ParentId { get; set; }
}