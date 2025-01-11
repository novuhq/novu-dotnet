using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Novu.Domain;

public static class NovuJsonSettings
{
    public static readonly JsonSerializerSettings DefaultSerializerSettings = new()
    {
        MissingMemberHandling = MissingMemberHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy(),
        },
        // General enum conversions are required to the in-place strings
        Converters = new List<JsonConverter>
        {
            new StringEnumConverter(),
        },
    };
}