using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Novu.JsonConverters;

/// <summary>
///     see https://www.tutorialdocs.com/article/webapi-data-binding.html
/// </summary>
public abstract class JsonCreationConverter<T> : JsonConverter
{
    public override bool CanWrite => true;

    protected abstract T Create(Type objectType, JObject jObject);

    public override bool CanConvert(Type objectType)
    {
        return typeof(T).IsAssignableFrom(objectType);
    }

    public override object ReadJson(
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

        var jObject = JObject.Load(reader);
        var target = Create(objectType, jObject);
        serializer.Populate(jObject.CreateReader(), target);
        return target;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}