using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step;

public class TimedConfig
{
    /// <summary>
    ///     24 Hour clock 18:00
    ///     TODO: need validator attribute
    /// </summary>
    [JsonProperty("atTime")]
    public string AtTime { get; set; }

    [JsonProperty("weekDays")] public DaysEnum[] WeekDays { get; set; }
    [JsonProperty("monthDays")] public int[] MonthDays { get; set; }
    [JsonProperty("ordinal")] public OrdinalEnum Ordinal { get; set; }
    [JsonProperty("ordinalValue")] public OrdinalValueEnum OrdinalValue { get; set; }
    [JsonProperty("monthlyType")] public MonthlyTypeEnum MonthlyType { get; set; }
}