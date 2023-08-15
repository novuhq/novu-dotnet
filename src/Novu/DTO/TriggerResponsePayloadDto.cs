using Newtonsoft.Json;

namespace Novu.DTO;

public class TriggerResponsePayloadDto
{
    [JsonProperty("acknowledged")] public bool Acknowledged { get; set; }

    [JsonProperty("status")] public string Status { get; set; }

    [JsonProperty("transactionId")] public string TransactionId { get; set; }
}