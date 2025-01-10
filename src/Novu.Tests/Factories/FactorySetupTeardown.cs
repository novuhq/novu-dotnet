using System.Reflection;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Novu.Tests.Factories;
/// <summary>
///     TODO: Requires v9 Xunit.DependencyInjection
/// </summary>
/// <param name="tracker"></param>
public class FactorySetupTeardown(Tracker tracker) /*: Xunit.DependencyInjection.BeforeAfterTest*/
{
    public /*override*/ async ValueTask AfterAsync([CanBeNull] object testClassInstance, MethodInfo methodUnderTest)
    {
        await tracker.RemoveAll();
    }
}