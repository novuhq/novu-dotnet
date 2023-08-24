using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Novu.JsonConverters;

/// <summary>
///     Solves the problem of
///     <code>
///         content: string | IEmailBlock[];
///     </code>
/// </summary>
public class TypeOrStringConverter<T> : JsonConverter
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
            return token.ToObject<T[]>();
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