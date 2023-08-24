using Newtonsoft.Json;
using Novu.JsonConverters;

namespace Novu.DTO;

/// <summary>
///     Client errors (eg HTTP status 4xx range) return reason for failure. Particularly <see cref="Message" /> is
///     the reason that is not found in the headers
/// </summary>
/// <remarks>
///     Novu returns 'application/json' and not the more specific 'application/problem+json' see
///     https://datatracker.ietf.org/doc/html/rfc7807
///     that Refit detects.
/// </remarks>
public class ErrorData
{
    /// <summary>
    ///     The actual reason for failure to start problem solving on. Sometime comes in as a string so convert to list
    /// </summary>
    [JsonProperty("message", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(ArrayConverter<string>))]
    public IList<string> Message { get; set; } = null!;

    /// <summary>
    ///     HTTP status code
    /// </summary>
    [JsonProperty("statusCode", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = null!;

    /// <summary>
    ///     Human readable description of the <see cref="Code">status code</see>
    /// </summary>
    [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; } = null!;
}