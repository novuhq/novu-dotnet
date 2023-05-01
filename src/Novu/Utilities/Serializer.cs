using Newtonsoft.Json;
using Novu.DTO;

namespace Novu.Utilities;

internal static class Serializer<T>
{
    /// <summary>
    /// Convert object type <see cref="T"/> to Json string.
    /// </summary>
    /// <param name="self">
    /// <see cref="T"/>
    /// </param>
    /// <returns>
    /// <see cref="string"/>
    /// </returns>
    public static string ToJson(T self) 
        => JsonConvert.SerializeObject(self, Converter.Settings);

    /// <summary>
    /// Convert json string to type <see cref="T"/> 
    /// </summary>
    /// <param name="json">
    /// <see cref="string"/>
    /// </param>
    /// <returns>
    /// <see cref="T"/>
    /// </returns>
    /// <exception cref="NullReferenceException"></exception>
    public static T FromJson(string json) 
        => JsonConvert.DeserializeObject<T>(json, Converter.Settings) 
           ?? throw new NullReferenceException("Incoming Json string cannot be null");
}