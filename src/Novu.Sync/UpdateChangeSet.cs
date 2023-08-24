using System.Collections.Generic;

namespace Novu.Sync;

public class UpdateChangeSet<T>
{
    public IEnumerable<T> ChangeTo { get; set; }
    public IEnumerable<T> Original { get; set; }
}