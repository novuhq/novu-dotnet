using System.Collections.Generic;
using System.Linq;

namespace Novu.Sync;

public static class Comparer
{
    /// <summary>
    ///     Creates a change set to be acted upon.
    /// </summary>
    /// <param name="templateSrc">Template source information</param>
    /// <param name="dest">Current state at destination</param>
    /// <param name="comparerId">Determines if the identity is the same</param>
    /// <param name="comparerDetails">Determins if the identity and the details are the same</param>
    /// <returns></returns>
    public static ChangeSet<T> Compare<T>(
        this IEnumerable<T> templateSrc,
        IEnumerable<T> dest,
        IEqualityComparer<T> comparerId = null,
        IEqualityComparer<T> comparerDetails = null)
    {
        templateSrc = templateSrc.ToList();
        dest = dest.ToList();

        var intersect = templateSrc.Intersect(dest, comparerId).ToList();
        var toAdd = templateSrc.Except(intersect, comparerId).ToList();
        var toRemove = dest.Except(intersect, comparerId).ToList();

        // now work out if there are updates
        // this requires more and needs to return the both sets because update templates
        // don't have IDs but are matched on Name identity that when
        // updates are made need to be resolved
        var potentialUpdates = dest.Except(toRemove, comparerId).ToList();
        var updateDest = dest.Intersect(potentialUpdates, comparerId).ToList();
        var updateSrc = templateSrc.Intersect(potentialUpdates, comparerId);

        var toUpdateSrc = updateSrc.Except(updateDest, comparerDetails).ToList();
        var toUpdateDest = updateDest.Intersect(toUpdateSrc, comparerId);

        return new ChangeSet<T>
        {
            Create = toAdd,
            Delete = toRemove,
            Update = new UpdateChangeSet<T>
            {
                Original = toUpdateDest,
                ChangeTo = toUpdateSrc,
            }
        };
    }
}