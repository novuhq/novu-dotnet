using Novu.Domain;

namespace Novu;

public class ApiClientConfiguration : IApiConfiguration
{
    public INovuClientConfiguration NovuClientConfiguration { get; set; }
}