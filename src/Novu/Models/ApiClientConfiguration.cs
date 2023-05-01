using Novu.Interfaces;

namespace Novu.Models;

public class ApiClientConfiguration : IApiConfiguration
{
    public INovuClientConfiguration NovuClientConfiguration { get; set; }
}