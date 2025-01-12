using Newtonsoft.Json;

namespace Novu.Domain.Models.MxRecords;

public class MxRecordStatus
{
    [JsonProperty("mxRecordConfigured")]
    public bool MxRecordConfigured { get; set; }
}