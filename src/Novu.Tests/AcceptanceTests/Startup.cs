using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Novu.Sync;

namespace Novu.Tests.AcceptanceTests;

/// <summary>
///     Automatically bootstrapped through Xunit lifecycle
///     see https://github.com/pengweiqhca/Xunit.DependencyInjection
/// </summary>
public class Startup
{
    public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        services
            .ConfigureTestServices(context)
            .RegisterNovuClientsWithExceptionHandler()
            .RegisterNovuSync()
            .RegisterFactories();
    }
}