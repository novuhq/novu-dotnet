using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Novu.Sync.Services;

public interface INovuSync<in T>
{
    /// <summary>
    ///     Take a template and look through the found organisation and synchronise.
    ///     Note: this current implementation takes control of an environment and deletes anything unknown to the templates
    /// </summary>
    /// <exception cref="AggregateException">
    ///     The <see cref="AggregateException.InnerExceptions" /> will return list of <see cref="Refit.ApiException" />
    /// </exception>
    Task Sync(T template);

    /// <summary>
    ///     List version <see cref="Sync(T)"/>
    /// </summary>
    /// <exception cref="AggregateException">
    ///     The <see cref="AggregateException.InnerExceptions" /> will return list of <see cref="Refit.ApiException" />
    /// </exception>
    Task Sync(IEnumerable<T> templates);
}