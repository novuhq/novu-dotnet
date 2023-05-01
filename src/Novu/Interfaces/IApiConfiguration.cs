namespace Novu.Interfaces;

public interface IApiConfiguration
{
    public INovuClientConfiguration NovuClientConfiguration { get; set; }
}