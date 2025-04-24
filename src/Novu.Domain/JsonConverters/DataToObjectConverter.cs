using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Novu.Domain.Models.Subscribers;

namespace Novu.Domain.JsonConverters;

/// <summary>
///     Novu requires the 'data' to be an object that was once an array of key/values. At that point, there was an
///     abstraction of <see cref="List{AdditionalData}" /> (or array).
/// </summary>
public class DataToObjectConverter : JsonConverter<List<AdditionalData>>
{
    public override List<AdditionalData> ReadJson(JsonReader reader, Type objectType,
        List<AdditionalData>? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        var list = new List<AdditionalData>();

        if (token.Type == JTokenType.Object)
        {
            foreach (var prop in token.Children<JProperty>())
            {
                list.Add(new AdditionalData
                {
                    Key = prop.Name,
                    Value = prop.Value.ToString() ?? string.Empty,
                });
            }
        }
        else
        {
            throw new JsonSerializationException("Expected JSON object for deserializing into List<AdditionalData>");
        }

        return list;
    }

    public override void WriteJson(JsonWriter writer, List<AdditionalData>? value, JsonSerializer serializer)
    {
        writer.WriteStartObject();

        if (value != null)
        {
            foreach (var item in value)
            {
                writer.WritePropertyName(item.Key);
                serializer.Serialize(writer, item.Value);
            }
        }

        writer.WriteEndObject();
    }
}