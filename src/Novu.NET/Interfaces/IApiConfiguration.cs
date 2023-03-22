namespace Novu.NET.Interfaces;

public interface IApiConfiguration
{
    public INovuClientConfiguration NovuClientConfiguration { get; set; }
}