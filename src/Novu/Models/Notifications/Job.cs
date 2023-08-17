using Newtonsoft.Json;

namespace Novu.Models.Notifications;

public class Job
{
    [JsonProperty("digest")] public Digest Digest { get; set; }

    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("step")] public Step Step { get; set; }

    [JsonProperty("_notificationId")] public string NotificationId { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    /// <summary>
    ///     TODO: ProviderEnum
    /// </summary>
    [JsonProperty("providerId")]
    public string ProviderId { get; set; }

    /// <summary>
    ///     TODO: ExecutionDetailsStatusEnum
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

    [JsonProperty("executionDetails")] public List<ExecutionDetail> ExecutionDetails { get; set; }
}