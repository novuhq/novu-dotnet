using System;
using System.Collections.Generic;
using Novu.Domain.Models.Layouts;

namespace Novu.Sync.Comparers;

public class LayoutDetailsComparer : IEqualityComparer<Layout>
{
    public bool Equals(Layout x, Layout y)
    {
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }

        return x.Content.Equals(y.Content) &&
               x.IsDefault == y.IsDefault &&
               x.Description == y.Description;
    }

    public int GetHashCode(Layout obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Name);
        return hashCode.ToHashCode();
    }
}