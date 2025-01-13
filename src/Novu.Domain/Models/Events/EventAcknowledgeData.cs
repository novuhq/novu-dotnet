using Newtonsoft.Json;

namespace Novu.Domain.Models.Events;

public class EventAcknowledgeData : NovuAcknowledgeData
{
    [JsonProperty("transactionId")] public string TransactionId { get; set; }
}