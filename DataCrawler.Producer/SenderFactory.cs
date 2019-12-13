using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataCrawler.Producer
{
    public class SenderFactory
    {
        public static ISender GetSender(string config)
        {
            dynamic senderconfig = JObject.Parse(config);
            string type = senderconfig.type;
            JObject configObject = senderconfig.config;
            switch (type.ToLower())
            {
                case "kafkaconfig":
                    return KafkaProducer.GetInstance(configObject.ToObject<SenderConfiguration>());
                case "firehose":
                    return new FireHoseSender(configObject.ToObject<SenderConfiguration>());
                default:
                    return null;

            }
        }
    }
}