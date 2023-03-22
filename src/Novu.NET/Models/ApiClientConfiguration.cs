using Novu.NET.Interfaces;

namespace Novu.NET.Models;

public class ApiClientConfiguration : IApiConfiguration
{
    public INovuClientConfiguration NovuClientConfiguration { get; set; }
}