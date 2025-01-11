using Novu.Domain.Models.Integrations;
using Novu.Domain.Models.Subscribers.Preferences;

namespace Novu.Sync.Models;

public class TemplateIntegration
{
    /// <summary>
    ///     This is the unique key
    /// </summary>
    /// <remarks>
    ///     Not sure how unique this is, it may be system-wide
    /// </remarks>
    public string Identifier { get; set; }

    /// <summary>
    ///     Known set of providers
    ///     TODO: work out how to enumerate but also inject
    /// </summary>
    public string ProviderId { get; set; }
    
    public ChannelTypeEnum Channel { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; } = true;
    
    /// <summary>
    ///     The combination of these change depending on the integration and is basically undocumented
    /// </summary>
    public Credentials Credentials { get; set; }

}