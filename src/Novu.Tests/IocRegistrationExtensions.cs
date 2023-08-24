using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Novu.Tests;

public static class IocRegistrationExtensions
{
    /// <summary>
    ///     Removes all registered <see cref="ServiceLifetime.Transient" /> registrations of <see cref="TService" /> and adds a
    ///     new registration which uses the <see cref="Func{TResult}" />.
    /// </summary>
    /// <typeparam name="TService">The type of service interface which needs to be placed.</typeparam>
    /// <param name="services"></param>
    /// <param name="implementationFactory">The implementation factory for the specified type.</param>
    /// <remarks>
    ///     from https://adamstorr.azurewebsites.net/blog/integration-testing-with-aspnetcore-3-1-swapping-dependency-with-moq
    /// </remarks>
    public static void SwapTransient<TService>(
        this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory)
    {
        if (services.Any(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient))
        {
            var serviceDescriptors = services
                .Where(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient).ToList();
            foreach (var serviceDescriptor in serviceDescriptors)
            {
                services.Remove(serviceDescriptor);
            }
        }

        services.AddTransient(typeof(TService), sp => implementationFactory(sp));
    }
}