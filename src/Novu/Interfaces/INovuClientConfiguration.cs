namespace Novu.Interfaces
{
    public interface INovuClientConfiguration
    {
        /// <summary>
        /// Full URL to where the Novu API is housed. Defaults to
        /// https://api.novu.co/v1
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Api Key used for authentication. Found on the Settings
        /// page > API Keys > API Key.
        /// </summary>
        string ApiKey { get; set; }
    }
}