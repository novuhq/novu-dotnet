using Newtonsoft.Json;

namespace Novu.DTO.Events;

public class EventAcknowledgeData : AcknowledgeData
{
    [JsonProperty("transactionId")] public string TransactionId { get; set; }
}