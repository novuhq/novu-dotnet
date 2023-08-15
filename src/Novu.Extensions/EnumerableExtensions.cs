using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Novu.Extensions;

public static class EnumerableExtensions
{
    public static bool IsNullOrEmpty<T>([CanBeNull] this IEnumerable<T> items) where T : class
    {
        return items is null || !items.Any();
    }
}