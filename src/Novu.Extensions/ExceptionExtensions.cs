using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace Novu.Extensions;

public static class ExceptionExtensions
{
    [NotNull]
    public static T ThrowArgumentExceptionIfNull<T>(this T anObject, string argumentName, string message = null)
        where T : class
    {
        return ThrowArgumentExceptionIf(anObject, o => o == null, argumentName, message);
    }

    [NotNull]
    public static T ThrowArgumentExceptionIf<T>(
        this T anObject,
        Func<T, bool> predicate,
        string argumentName,
        string message)
    {
        if (predicate(anObject))
        {
            throw new ArgumentException(argumentName, message);
        }

        return anObject;
    }

    [NotNull]
    public static T ThrowArgumentNullExceptionIfNull<T>(this T anObject, string argumentName, string message = null)
        where T : class
    {
        return ThrowArgumentNullExceptionIf(anObject, o => o == null, argumentName, message);
    }

    [NotNull]
    public static T ThrowArgumentNullExceptionIf<T>(
        this T anObject,
        Func<T, bool> predicate,
        string argumentName,
        string message)
    {
        if (predicate(anObject))
        {
            throw new ArgumentNullException(argumentName, message);
        }

        return anObject;
    }

    [NotNull]
    public static Guid ThrowAccessDeniedExceptionIfNull(this Guid anObject, string message = "Access denied")
    {
        return ThrowAccessDeniedExceptionIf(anObject, g => Guid.Empty.Equals(g), message);
    }

    [NotNull]
    public static T ThrowAccessDeniedExceptionIfNull<T>(this T anObject, string message = "Access denied")
        where T : class
    {
        return ThrowAccessDeniedExceptionIf(anObject, o => o == null, message);
    }

    [NotNull]
    public static T ThrowAccessDeniedExceptionIf<T>(this T anObject, Func<T, bool> predicate, string message)
    {
        if (predicate(anObject))
        {
            throw new UnauthorizedAccessException(message);
        }

        return anObject;
    }

    [NotNull]
    public static T ThrowInvalidDataExceptionIfNull<T>(this T anObject, string message)
        where T : class
    {
        return ThrowInvalidDataExceptionIf(anObject, o => o == null, message);
    }


    [NotNull]
    public static T ThrowInvalidDataExceptionIfNull<T>(this T anObject, Func<string> message)
        where T : class
    {
        return ThrowInvalidDataExceptionIf(anObject, o => o == null, message);
    }

    public static T ThrowInvalidDataExceptionIfNotNull<T>(this T anObject, string message)
        where T : class
    {
        return ThrowInvalidDataExceptionIf(anObject, o => o != null, message);
    }

    [NotNull]
    public static IEnumerable<T> ThrowInvalidDataExceptionIfNullOrEmpty<T>(
        this IEnumerable<T> anObject,
        string message)
        where T : class
    {
        return ThrowInvalidDataExceptionIf(anObject, o => o.IsNullOrEmpty(), message);
    }

    [NotNull]
    public static string ThrowInvalidDataExceptionIfNullOrWhiteSpace(this string str, Func<string> message)
    {
        return ThrowInvalidDataExceptionIf(str, string.IsNullOrWhiteSpace, message?.Invoke() ?? string.Empty);
    }

    [NotNull]
    public static string ThrowInvalidDataExceptionIfNullOrWhiteSpace(this string str, string message)
    {
        return ThrowInvalidDataExceptionIf(str, string.IsNullOrWhiteSpace, message);
    }

    [NotNull]
    public static string ThrowInvalidDataExceptionIfNullOrEmpty(this string str, string message)
    {
        return ThrowInvalidDataExceptionIf(str, string.IsNullOrEmpty, message);
    }

    public static string ThrowInvalidDataExceptionIfNotNullOrWhiteSpace(this string anObject, string message)
    {
        return ThrowInvalidDataExceptionIf(anObject, s => !string.IsNullOrWhiteSpace(s), message);
    }

    [NotNull]
    public static T? ThrowInvalidDataExceptionIfNull<T>(this T? anObject, string message)
        where T : struct
    {
        return ThrowInvalidDataExceptionIf(anObject, o => !o.HasValue, message);
    }

    public static T? ThrowInvalidDataExceptionIfNotNull<T>(this T? anObject, string message)
        where T : struct
    {
        return ThrowInvalidDataExceptionIf(anObject, o => o.HasValue, message);
    }

    [NotNull]
    public static IEnumerable<T> ThrowInvalidDataExceptionIfAny<T>(this IEnumerable<T> query, string message)
    {
        return ThrowInvalidDataExceptionIf(query, o => query.Any(), message);
    }


    public static T ThrowInvalidDataExceptionIf<T>(this T anObject, Func<T, bool> predicate, string message)
    {
        if (predicate(anObject))
        {
            throw new InvalidDataException(message);
        }

        return anObject;
    }

    public static T ThrowInvalidDataExceptionIf<T>(this T anObject, Func<T, bool> predicate, Func<string> message)
    {
        if (predicate(anObject))
        {
            throw new InvalidDataException(message?.Invoke() ?? string.Empty);
        }

        return anObject;
    }

    [NotNull]
    public static T? ThrowObjectNotFoundExceptionIfNull<T>(this T? anObject, string message = "Not found")
        where T : struct
    {
        return ThrowObjectNotFoundExceptionIf(anObject, o => !o.HasValue, message);
    }

    [NotNull]
    public static T ThrowObjectNotFoundExceptionIfNull<T>(this T anObject, Func<string> message)
        where T : class
    {
        return ThrowObjectNotFoundExceptionIf(anObject, o => o == null, message?.Invoke() ?? string.Empty);
    }

    [NotNull]
    public static T ThrowObjectNotFoundExceptionIfNull<T>(this T anObject, string message = "Not found")
        where T : class
    {
        return ThrowObjectNotFoundExceptionIf(anObject, o => o == null, message);
    }

    public static int ThrowObjectNotFoundExceptionIfZero(this int id, string message = "Not found")
    {
        return ThrowObjectNotFoundExceptionIf(id, o => o == 0, message);
    }

    public static long ThrowObjectNotFoundExceptionIfZero(this long id, string message = "Not found")
    {
        return ThrowObjectNotFoundExceptionIf(id, o => o == 0L, message);
    }


    [NotNull]
    public static T ThrowObjectNotFoundExceptionIf<T>(this T anObject, Func<string> message)
        where T : class
    {
        return ThrowObjectNotFoundExceptionIf(anObject, o => o == null, message?.Invoke() ?? string.Empty);
    }

    [NotNull]
    public static T ThrowObjectNotFoundExceptionIf<T>(this T anObject, Func<T, bool> predicate, string message)
    {
        if (predicate(anObject))
        {
            throw new ObjectNotFoundException(message);
        }

        return anObject;
    }

    [NotNull]
    public static T ThrowConfigurationErrorsExceptionIfNull<T>(this T anObject, Func<string> message)
    {
        return ConfigurationErrorsExceptionIf(anObject, o => o == null, message);
    }

    [NotNull]
    public static T ThrowConfigurationErrorsExceptionIfNull<T>(this T anObject, string message)
    {
        return ConfigurationErrorsExceptionIf(anObject, o => o == null, () => message);
    }

    public static T ThrowConfigurationErrorsExceptionIfNotNull<T>(this T anObject, Func<string> message)
    {
        return ConfigurationErrorsExceptionIf(anObject, o => o != null, message);
    }

    [NotNull]
    public static string ThrowConfigurationErrorsExceptionIfNullOrWhiteSpace(this string str, string message)
    {
        return ConfigurationErrorsExceptionIf(str, string.IsNullOrWhiteSpace, () => message);
    }

    [NotNull]
    public static string ThrowConfigurationErrorsExceptionIfNullOrEmpty(this string str, Func<string> message)
    {
        return ConfigurationErrorsExceptionIf(str, string.IsNullOrEmpty, message);
    }

    [NotNull]
    public static string ThrowConfigurationErrorsExceptionIfNullOrEmpty(this string str, string message)
    {
        return ConfigurationErrorsExceptionIf(str, string.IsNullOrEmpty, () => message);
    }

    public static string ThrowConfigurationErrorsExceptionIfNotNullOrWhiteSpace(
        this string anObject,
        string message)
    {
        return ConfigurationErrorsExceptionIf(anObject, s => !string.IsNullOrWhiteSpace(s), () => message);
    }

    [NotNull]
    public static T ConfigurationErrorsExceptionIf<T>(
        this T anObject,
        Func<T, bool> predicate,
        Func<string> message)
    {
        if (predicate(anObject))
        {
            throw new ConfigurationErrorsException(message?.Invoke());
        }

        return anObject;
    }
}