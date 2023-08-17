using Refit;

namespace Novu.DTO.Notifications;

public class NotificationQueryParams
{
    [AliasAs("channels")] public string[] Channels { get; set; }
    [AliasAs("templates")] public string[] Templates { get; set; }
    [AliasAs("emails")] public string[] Emails { get; set; }
    [AliasAs("subscriberIds")] public string[] SubscriberIds { get; set; }
    [AliasAs("search")] public string Search { get; set; }
    [AliasAs("page")] public int Page { get; set; }
    [AliasAs("transactionId")] public string Transactionid { get; set; }
}