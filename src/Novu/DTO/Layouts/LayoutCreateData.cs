using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Novu.Models.Workflows.Step.Message;

namespace Novu.DTO.Layouts;

/// <summary>
///     see https://docs.novu.co/api/layout-creation/
/// </summary>
public class LayoutCreateData
{
    public const string BodyExpression = "{{{body}}}";
    public const string VariableFormat = "{{{{{0}}}}}";

    /// <summary>
    ///     User defined custom name and provided by the user that will name the Layout created.
    /// </summary>
    [Required]
    [JsonProperty("name", Required = Required.Always)]
    public string Name { get; set; }

    /// <summary>
    ///     User description of the layout
    /// </summary>
    [MaxLength(100)]
    [JsonProperty("description")]
    public string Description { get; set; }

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
}