using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Novu.JsonConverters;

/// <summary>
///     ConvertToInt a {T} or Array{T} to an Array{T}
///     This is required where a select form will return a single value or a list of values.
///     from https://briancaos.wordpress.com/2019/08/26/newtonsoft-serialize-property-that-is-an-array-and-a-string/
/// </summary>
/// <example>
///     Serialise a property that is a string or an array of strings:
///     <code>
///     {  field: 'http://example.com/i/1' }
///     {  field: ['http://example.com/i/1'] }
/// </code>
///     These will both be serialised to:
///     public class WorkerResponseCreateDataRepresentation {
///     [DataMember(Name = "field")]
///     [JsonConverter(typeof(ArrayConverter
///     <string>
///         ))]
///         public List
///         <string>
///             Field { get; set; }
///             }
/// </example>
public class ArrayConverter<T> : JsonConverter
{
    public override bool CanWrite => false;

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<T>);
    }

    public override object ReadJson(
        JsonReader reader,
        Type objectType,
        object existingValue,
        JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        if (token.Type == JTokenType.Array)
        {
            return token.ToObject<List<T>>();
        }

        return new List<T> { token.ToObject<T>() };
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}