using Novu.NET.Interfaces;

namespace Novu.NET.DTO;

public class ApiClientConfiguration : IApiConfiguration
{
    public INovuClientConfiguration NovuClientConfiguration { get; set; }
}