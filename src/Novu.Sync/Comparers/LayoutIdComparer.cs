using System;
using System.Collections.Generic;
using Novu.DTO.Layouts;

namespace Novu.Sync.Comparers;

public class LayoutIdComparer : IEqualityComparer<Layout>
{
    public bool Equals(Layout x, Layout y)
    {
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }

        return true;
    }

    public int GetHashCode(Layout obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Name);
        return hashCode.ToHashCode();
    }
}
