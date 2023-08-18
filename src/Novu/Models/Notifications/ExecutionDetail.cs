using Newtonsoft.Json;

namespace Novu.Models.Notifications;

public class ExecutionDetail
{
    [JsonProperty("_id")] public string Id { get; set; }

    [JsonProperty("_jobId")] public string JobId { get; set; }

    [JsonProperty("_notificationTemplateId")]
    public string NotificationTemplateId { get; set; }

    [JsonProperty("_notificationId")] public string NotificationId { get; set; }
    [JsonProperty("_subscriberId")] public string SubscriberId { get; set; }
    [JsonProperty("_messageId")] public string MessageId { get; set; }

    [JsonProperty("providerId")] public string ProviderId { get; set; }
    [JsonProperty("transactionId")] public string TransactionId { get; set; }

    /// <summary>
    ///     TODO: ExecutionDetailsStatusEnum
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("detail")] public string Detail { get; set; }
    [JsonProperty("channel")] public string Channel { get; set; }

    [JsonProperty("source")] public string Source { get; set; }

    [JsonProperty("isTest")] public bool IsTest { get; set; }

    [JsonProperty("isRetry")] public bool IsRetry { get; set; }

    [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }
}