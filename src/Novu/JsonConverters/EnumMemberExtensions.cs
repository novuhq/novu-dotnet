using System.Runtime.Serialization;

namespace Novu.JsonConverters;

/// <summary>
///     Look through EnumMember(Value="xx") Attribute to create the Enum
/// </summary>
public static class EnumMemberExtensions
{
    public static bool TryParseEnumMember<T>(this string value, out T result)
        where T : struct, Enum
    {
        var enumType = typeof(T);
        foreach (var name in Enum.GetNames(enumType))
        {
            var attr = enumType
                .GetField(name)
                .GetCustomAttributes(typeof(EnumMemberAttribute), true)
                .Cast<EnumMemberAttribute>()
                .Single();
            if (attr.Value == value)
            {
                return Enum.TryParse(name, true, out result);
            }
        }

        result = default;
        return false;
    }
}