using Novu.Domain.Models.Workflows;
using Novu.Domain.Models.Workflows.Step;

namespace Novu.Sync.Models;

public class TemplateWorkflow
{
    public string Name { get; set; }
    public string WorkflowGroupId { get; set; }
    public string[] Tags { get; set; }
    public string Description { get; set; }

    /// <summary>
    ///     While you can add steps on creation, they are partial (eg senderName, subject) and must be
    ///     added as part of the update
    /// </summary>
    public Step[] Steps { get; set; }

    public bool Active { get; set; }
    public bool Draft { get; set; }
    public bool Critical { get; set; }

    /// <remarks>
    ///     This is a workflow group in the api see https://docs.novu.co/api/create-workflow-group/
    /// </remarks>
    public PreferenceChannels PreferenceSettings { get; set; }

    public string BlueprintId { get; set; }

    /// <summary>
    ///     NotificationTemplateCustomData is basically an untyped dictionary
    /// </summary>
    public object Data { get; set; }
}