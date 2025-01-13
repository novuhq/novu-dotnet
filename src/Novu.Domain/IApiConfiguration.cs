namespace Novu.Domain;

public interface IApiConfiguration
{
    public INovuClientConfiguration NovuClientConfiguration { get; set; }
}