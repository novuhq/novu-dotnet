using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step;

/// <summary>
///     Represents the metadata for a regular digest step in a workflow.
/// </summary>
/// <remarks>
///     - The <see cref="Type" /> property determines whether this metadata applies to a regular digest or a backoff-based
///     digest.
///     - The <see cref="Backoff" /> property controls whether backoff logic is enabled.
///     - If <see cref="Backoff" /> is true, <see cref="BackoffAmount" /> and <see cref="BackoffUnit" /> determine the
///     backoff period.
///     - <see cref="BackoffUnit" /> must always be set to a valid <see cref="UnitEnum" /> value to ensure proper API
///     compatibility.
///     - To avoid serialization issues, <see cref="BackoffAmount" /> and <see cref="BackoffUnit" /> are set valid values
///     to turn off functionality and are serialised with <see cref="BackoffUnit" />
/// </remarks>
public class DigestRegularMetadata : DigestBaseMetadata, IWorkflowMetaData
{
    /// <summary>
    ///     The type of digest, either Regular or Backoff.
    /// </summary>
    /// <remarks>
    ///     The API currently does not use <see cref="DigestTypeEnum.Backoff" />.
    /// </remarks>
    [Required]
    [JsonProperty("type")]
    public DigestTypeEnum Type { get; set; } = DigestTypeEnum.Regular;

    /// <summary>
    ///     Indicates whether backoff logic is applied.
    /// </summary>
    [JsonProperty("backoff", DefaultValueHandling = DefaultValueHandling.Populate)]
    public bool Backoff { get; set; }

    /// <summary>
    ///     The number of events within the specified <see cref="BackoffUnit" /> to trigger a digest.
    /// </summary>
    /// <remarks>
    ///     This field is only relevant if <see cref="Backoff" /> is true. 
    /// </remarks>
    [JsonProperty("backoffAmount", DefaultValueHandling = DefaultValueHandling.Populate)]
    public int BackoffAmount { get; set; }

    /// <summary>
    ///     The unit of time for the backoff period.
    /// </summary>
    /// <remarks>
    ///     This field is required by the backend, even if <see cref="Backoff" /> is false.
    ///     A default value of <see cref="UnitEnum.Seconds" /> is set to prevent serialization errors.
    /// </remarks>
    [JsonProperty("backoffUnit")]
    public UnitEnum BackoffUnit { get; set; } = UnitEnum.Seconds;

    /// <summary>
    ///     Determines whether update mode is enabled.
    /// </summary>
    [JsonProperty("updateMode")]
    public bool UpdateMode { get; set; }
}