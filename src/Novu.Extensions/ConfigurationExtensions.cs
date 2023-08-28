using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Novu.Models;

namespace Novu.Extensions;

public static class ConfigurationExtensions
{
    /// <summary>
    ///     Load up the configuration from (based on the directory) the running process
    ///     - appsettings.json
    ///     - appsettings.[env].json
    ///     - appsettings.[dev_user].json
    ///     - environment variables
    /// </summary>
    public static IConfigurationRoot CreateConfigurationRoot(this string jsonFileName)
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(jsonFileName, true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("USER")}.json", true)
            .AddEnvironmentVariables()
            .Build();
    }

    /// <summary>
    ///     Get a configuration based on a string key and throw an exception if null or empty
    /// </summary>
    public static string GetConfiguration(this IConfiguration configuration, string section)
    {
        return configuration.GetSection(section)?
            .Value
            .ThrowConfigurationErrorsExceptionIfNullOrEmpty($"Error: Configuration variable '{section}' must be set");
    }


    /// <summary>
    ///     Return the <see cref="NovuClientConfiguration" /> from the settings file
    /// </summary>
    public static NovuClientConfiguration GetNovuClientConfiguration(this IConfiguration configuration)
    {
        var novuConfiguration = new NovuClientConfiguration();
        configuration.GetSection(Settings.NovuSection).Bind(novuConfiguration);

        var novuConfigurationUrl = Environment.GetEnvironmentVariable("NOVU_API_URL");
        if (novuConfigurationUrl is not null)
        {
            novuConfiguration.Url = novuConfigurationUrl;
        }

        var novuConfigurationApiKey = Environment.GetEnvironmentVariable("NOVU_API_KEY");
        if (novuConfigurationApiKey is not null)
        {
            novuConfiguration.ApiKey = novuConfigurationApiKey;
        }

        return novuConfiguration;
    }
}