using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Models.Workflows.Step;

public class DigestTimedMetadata : DigestBaseMetadata, IWorkflowMetaData
{
    [Required] [JsonProperty("type")] public DigestTypeEnum Type { get; private set; } = DigestTypeEnum.Timed;

    /// <summary>
    /// </summary>
    [JsonProperty("timed")]
    public TimedConfig Timed { get; set; }
}