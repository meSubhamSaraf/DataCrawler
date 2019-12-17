using System.Collections.Generic;

namespace DataCrawler.Model.Entity
{
    public class AppSetting
    {
        public User[] users { get; set; }
        public string environment { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string type { get; set; }
        public Config[] configs { get; set; }
    }

    public class Config
    {
        public string streamname { get; set; }
        public string kafkaendpoint { get; set; }
        public int numberOfPartitions { get; set; }
    }

    public class MessageQueueRequest
    {
        public string StreamName { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
    }

    public class MessageQueueResponse
    {
        public MessageStatus Status { get; set; }
        public List<Error> Errors { get; set; }
    }

    public enum MessageStatus { Queuued, NotQueued}

    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}