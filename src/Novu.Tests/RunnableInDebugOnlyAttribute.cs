using System.Diagnostics;
using Xunit;

namespace Novu.Tests;

/// <summary>
///     see https://lostechies.com/jimmybogard/2013/06/20/run-tests-explicitly-in-xunit-net/
/// </summary>
/// <remarks>
///     Keep an eye on [Explicit] attribute
///     see https://github.com/xunit/xunit/issues/2518
/// </remarks>
public sealed class RunnableInDebugOnlyAttribute : FactAttribute
{
    public RunnableInDebugOnlyAttribute()
    {
        if (!Debugger.IsAttached)
        {
            Skip = "Run in debug mode to execute";
        }
    }
}