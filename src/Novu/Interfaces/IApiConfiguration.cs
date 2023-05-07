namespace Novu.Interfaces
{
    public interface IApiConfiguration
    {
        INovuClientConfiguration NovuClientConfiguration { get; set; }
    }
}