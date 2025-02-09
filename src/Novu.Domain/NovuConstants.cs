using System.Reflection;

namespace Novu.Domain;

public static class NovuConstants
{
    public static readonly int MaxPageSize = 100;

    /// <summary>
    ///     Returns the properly formatted User-Agent header string for the `novu-dotnet` package,
    ///     including the version retrieved from the NuGet package version.
    /// </summary>
    /// <returns>
    ///     A string in the format `novu-dotnet/{version}`, where {version} is the version of the NuGet package.
    ///     If no version is found, it defaults to `novu-dotnet/0.0.0`.
    /// </returns>
    /// <remarks>
    ///     The version is retrieved from the assembly's <see cref="AssemblyInformationalVersionAttribute" />.
    ///     If the version is not specified in the assembly, it falls back to `0.0.0` as the default version.
    ///     This ensures compliance with the HTTP specification for the User-Agent header format, as outlined in RFC 7231.
    /// </remarks>
    /// <example>
    ///     Example usage:
    ///     <code>
    ///         string userAgent = NovuConstants.UserAgent();
    ///         Console.WriteLine(userAgent);  // Outputs: novu-dotnet/1.2.3 (if version is 1.2.3)
    ///     </code>
    /// </example>
    public static string UserAgent()
    {
        // Add a User-Agent header if enabled
        var version = Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
            .InformationalVersion ?? "0.0.0";
        return $"novu-dotnet/{version}";
    }
}