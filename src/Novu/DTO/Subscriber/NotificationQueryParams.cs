using Refit;

namespace Novu.DTO.Subscriber;

public class InAppFeedQueryParams
{
    [AliasAs("page")] public int Page { get; set; }
    [AliasAs("limit")] public int Limit { get; set; }
    [AliasAs("read")] public bool Read { get; set; }
    [AliasAs("seen")] public bool Seen { get; set; }
}