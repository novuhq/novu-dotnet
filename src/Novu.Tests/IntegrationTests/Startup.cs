using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Novu.Tests.IntegrationTests;

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
            .RegisterFactories();
    }
}