using System.Runtime.Serialization;

namespace Novu.Domain.Utils;

public static class EnumMemberExtensions
{
    /// <summary>
    ///     Look through EnumMember(Value="xx") Attribute to create the Enum
    /// </summary>
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

    /// <summary>
    ///     Given the enum has an <see cref="EnumMemberAttribute" /> return the value from
    ///     <see cref="EnumMemberAttribute.Value" />
    /// </summary>
    /// <remarks>
    ///     from https://stackoverflow.com/questions/10418651/using-enummemberattribute-and-doing-automatic-string-conversions
    /// </remarks>
    public static string ToEnumString<T>(this T type)
        where T : Enum
    {
        var enumType = typeof(T);
        var name = Enum.GetName(enumType, type);
        var enumMemberAttribute = (enumType
                                       .GetField(name ?? string.Empty)
                                       ?.GetCustomAttributes(typeof(EnumMemberAttribute), true) as EnumMemberAttribute[] ??
                                   Array.Empty<EnumMemberAttribute>())
            .Single();
        return enumMemberAttribute.Value;
    }
}