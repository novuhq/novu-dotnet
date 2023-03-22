using Novu.NET.Interfaces;

namespace Novu.NET.DTO;

public class NovuClientConfiguration : INovuClientConfiguration
{
    public string Url { get; set; } = "https://api.novu.co/v1";
    
    public string ApiKey { get; set; }
}