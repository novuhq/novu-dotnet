using Refit;

namespace Novu.DTO.Subscribers;

public class SubscriberQueryParams
{
    [AliasAs("page")] public int Page { get; set; } = 0;
    [AliasAs("limit")] public int Limit { get; set; } = 100;
    [AliasAs("read")] public bool Read { get; set; }
    [AliasAs("seen")] public bool Seen { get; set; }
}