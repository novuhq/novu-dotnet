namespace Novu.Common
{
    public static class Endpoints
    {
        public const string Topics = "/topics";
    
        public static string TopicSubscribers(string topicKey) => $"/topics/{topicKey}/subscribers";
    
        public static string TopicSubscriber(string topicKey, string subscriberId) => $"/topics/{topicKey}/subscribers/{subscriberId}";
    
        public static string TopicRemoveSubscriber(string topicKey) => $"/topics/{topicKey}/subscribers/removal";
    
        public static string Topic(string topicKey) => $"/topics/{topicKey}";
    }
}