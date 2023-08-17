using Newtonsoft.Json;

namespace Novu.DTO.Notifications;

public class NotificationStats
{
    [JsonProperty("weeklySent")] public int WeeklySent { get; set; }

    [JsonProperty("monthlySent")] public int MonthlySent { get; set; }
}