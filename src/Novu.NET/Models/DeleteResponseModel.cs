using Newtonsoft.Json;

namespace Novu.NET.Models;

public partial class DeleteResponseModel
{
    [JsonProperty("acknowledged")]
    public bool Acknowledged { get; set; }
    
    [JsonProperty("status")]
    public string Status { get; set; }
}

public partial class DeleteResponseModel
{
    public static DeleteResponseModel FromJson(string json) =>
        JsonConvert.DeserializeObject<DeleteResponseModel>(json, Converter.Settings);
}