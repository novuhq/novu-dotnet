using Refit;

namespace Novu.DTO.Messages;

public class MessageQueryParams
{
    [AliasAs("channel")] public string Channel { get; set; }
    [AliasAs("subscriberId")] public string SubscriberId { get; set; }
    [AliasAs("search")] public string Search { get; set; }
    [AliasAs("page")] public int Page { get; set; }
    [AliasAs("transactionId")] public string TransactionId { get; set; }
}