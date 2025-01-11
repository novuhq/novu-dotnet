namespace Novu.Domain.Models.Workflows.Step.Message;

public interface IMessageTemplate
{
    StepTypeEnum Type { get; set; }

    /// <summary>
    ///     Polymorphic between string (code) and typed EmailBlock[]
    /// </summary>
    object Content { get; set; }

    MessageTemplateContentType ContentType { get; set; }

    bool Deleted { get; set; }

    TemplateVariable[] Variables { get; set; }

    /// <summary>
    ///     Layout has three lifecycles (create, update and read) and the create and update use the non-underscore
    ///     whereas the read uses underscore.
    ///
    ///     The problems lies that these are nested objects that the API doesn't create as sub-resources to manage.
    ///
    ///     Therefore the implementation must deal with READ/WRITE in situ.
    /// </summary>
    /// <remarks>
    ///     The same problem for <see cref="FeedId"/>
    /// </remarks>
    public string? LayoutId { get; set; }
    // ReSharper disable once InconsistentNaming
    public string? _layoutId { get; set; }

    public Actor Actor { get; set; }
}