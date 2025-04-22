using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Novu.Domain.JsonConverters;

/// <summary>
///     Solves the problem of and that it will deserialise to type and work out if it needs to an array or object.
///     <remarks>
///         Only had in the type rather than Array
///     </remarks>
///     <code>
///         content: string | IEmailBlock | IEmailBlock[];
///     </code>
///     <example>
///         [JsonProperty("content")]
///         [JsonConverter(typeof(ArrayObjectOrStringConverter{EmailBlock}))]
///         public object Content { get; set; }
///     </example>
/// </summary>
public class ArrayObjectOrStringConverter<T> : JsonConverter
{
    public override bool CanWrite => true;

    public override bool CanConvert(Type objectType)
    {
        return typeof(string).IsAssignableFrom(objectType) || typeof(T).IsAssignableFrom(objectType);
    }
    
    public override object? ReadJson(
        JsonReader reader,
        Type objectType,
        object existingValue,
        JsonSerializer serializer)
    {
        if (reader == null)
        {
            throw new ArgumentNullException("reader");
        }

        if (serializer == null)
        {
            throw new ArgumentNullException("serializer");
        }

        if (reader.TokenType == JsonToken.Null)
        {
            return null;
        }

        var token = JToken.Load(reader);

        if (token.Type is JTokenType.Array)
        {
            var readJson = token.ToObject<T[]>();
            return readJson;
        }

        if (token.Type is JTokenType.Object)
        {
            return token.ToObject<T>();
        }

        return token.ToString();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}