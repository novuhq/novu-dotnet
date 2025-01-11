using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Novu.Extensions;
using Xunit.DependencyInjection.Logging;

namespace Novu.Tests;

public static class StartUpRegistrationExtensions
{
    /// <summary>
    ///     Used as the basis for any integration tests DI
    /// </summary>
    public static IServiceCollection ConfigureTestServices(this IServiceCollection services, HostBuilderContext context)
    {
        context.SetNovuConfiguration("Integration");
        return services
                // register external loggers and then retain with serilog
                .AddLogging(lb => lb.AddXunitOutput())
            ;
    }
}