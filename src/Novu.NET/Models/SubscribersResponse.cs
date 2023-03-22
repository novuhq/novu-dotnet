using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Novu.NET.Models;

public partial class SubscribersResponse
{
    [JsonProperty("page")]
    public int Page { get; set; }
    
    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }
    
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }
    
    [JsonProperty("data")]
    public SubscriberModel[] Subscribers { get; set; }
}

public partial class SubscribersResponse
{
    /// <summary>
    /// Convert a SubscribersResponse to a <see cref="SubscribersResponse"/> object.
    /// </summary>
    /// <param name="json">Inbound JSON</param>
    /// <returns>
    /// <see cref="SubscribersResponse"/>
    /// </returns>
    public static SubscribersResponse FromJson(string json) =>
        JsonConvert.DeserializeObject<SubscribersResponse>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this SubscribersResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
        {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
    };
}