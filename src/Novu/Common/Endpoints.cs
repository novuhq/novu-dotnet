namespace Novu.Common;

public static class Endpoints
{
    public const string Topics = "/topics";
    
    public static string TopicSubscribers(string topicKey) => $"/topics/{topicKey}/subscribers";
}