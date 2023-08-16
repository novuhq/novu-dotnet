using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Models.Workflows.Step;

public class DigestRegularMetadata : DigestBaseMetadata, IWorkflowMetaData
{
    /// <summary>
    ///     Allowed <see cref="DigestTypeEnum.Regular" /> and <see cref="DigestTypeEnum.Backoff" />
    /// </summary>
    /// <remarks>
    ///     In working with the API <see cref="DigestTypeEnum.Backoff" /> doesn't appear to be used
    /// </remarks>
    [Required]
    [JsonProperty("type")]
    public DigestTypeEnum Type { get; set; } = DigestTypeEnum.Regular;

    /// <summary>
    ///     Only if frequent events occur
    /// </summary>
    [JsonProperty("backoff")]
    public bool Backoff { get; set; }

    /// <summary>
    ///     More than 1 event in the last amount by unit if <see cref="Backoff" /> true
    /// </summary>
    /// <see cref="BackoffUnit" />
    [JsonProperty("backoffAmount")]
    public int BackoffAmount { get; set; }

    /// <summary>
    ///     More than 1 event in the last amount by unit if <see cref="Backoff" /> true
    /// </summary>
    /// <see cref="BackoffUnit" />
    [JsonProperty("backoffUnit")]
    public UnitEnum BackoffUnit { get; set; }

    [JsonProperty("updateMode")] public bool UpdateMode { get; set; }
}