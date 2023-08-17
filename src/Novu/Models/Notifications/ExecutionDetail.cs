using Newtonsoft.Json;

namespace Novu.Models.Notifications;

public class ExecutionDetail
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("_jobId")] public string JobId { get; set; }

    /// <summary>
    ///     TODO: ProviderEnum
    /// </summary>
    /// [JsonProperty("providerId")] public string ProviderId { get; set; }
    /// <summary>
    ///     TODO: ExecutionDetailsStatusEnum
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("detail")] public string Detail { get; set; }

    [JsonProperty("source")] public string Source { get; set; }

    [JsonProperty("isTest")] public bool IsTest { get; set; }

    [JsonProperty("isRetry")] public bool IsRetry { get; set; }

    [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }
}