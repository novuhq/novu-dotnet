using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Models.Workflows.Step;

public class DelayScheduledMetadata : IWorkflowMetaData
{
    [Required] [JsonProperty("type")] public DelayTypeEnum Type { get; private set; } = DelayTypeEnum.Scheduled;

    /// <summary>
    ///     The path to the variable in the 'payload' that has a date. Assume that that is ISO Date.
    /// </summary>
    [Required]
    [JsonProperty("delayPath")]
    public string DelayPath { get; set; }
}