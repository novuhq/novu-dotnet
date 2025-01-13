using Novu.Domain.Models.Workflows.Step.Message;

namespace Novu.Sync.Models;

public class TemplateLayout
{
    public string Name { get; set; }
    public string Description { get; set; }

    /// <summary>
    ///     User defined content for the layout. Ensure that variables specified in the content via {{ x }} are
    ///     also included in the <see cref="Variables" />
    /// </summary>
    /// <remarks>
    ///     This content must contain "{{{body}}}" with no spaces
    /// </remarks>
    public string Content { get; set; }

    /// <summary>
    ///     User defined variables to render in the layout placeholders.
    /// </summary>
    /// <remarks>
    ///     Note: the documentation says it is a string but it isn't.
    /// </remarks>
    public TemplateVariable[] Variables { get; set; }

    public bool IsDefault { get; set; }
}