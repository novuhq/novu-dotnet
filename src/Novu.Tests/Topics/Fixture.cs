using Novu.Models;

namespace Novu.Tests.Topics;

public class Fixture : IDisposable
{
    public NovuClient NovuClient { get; }
    
    public Fixture()
    {
        var novuConfiguration = new NovuClientConfiguration
        {
            ApiKey = Environment.GetEnvironmentVariable("NOVU_API_KEY") ?? throw new InvalidOperationException(),
        };
        var novu = new NovuClient(novuConfiguration);

        NovuClient = novu;
    }
    
    public async void Dispose()
    {
        
    }
}