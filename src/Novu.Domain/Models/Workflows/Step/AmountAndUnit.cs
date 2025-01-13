using Newtonsoft.Json;

namespace Novu.Domain.Models.Workflows.Step;

public class AmountAndUnit
{
    /// <summary>
    ///     Digest events will be send after amount by unit
    /// </summary>
    /// <see cref="Unit" />
    [JsonProperty("amount")]
    public int Amount { get; set; }

    /// <summary>
    ///     Digest events will be send after amount and unit
    /// </summary>
    /// <see cref="Amount" />
    [JsonProperty("unit")]
    public UnitEnum Unit { get; set; }
}