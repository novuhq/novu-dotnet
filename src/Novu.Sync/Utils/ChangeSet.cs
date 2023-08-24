using System.Collections.Generic;

namespace Novu.Sync.Utils;

public class ChangeSet<T>
{
    public IEnumerable<T> Create { get; set; }
    public IEnumerable<T> Delete { get; set; }
    public UpdateChangeSet<T> Update { get; set; }
}