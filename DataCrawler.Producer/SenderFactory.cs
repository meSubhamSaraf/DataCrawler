using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataCrawler.Producer
{
    public class SenderFactory
    {
        private Dictionary<string, IProducer> _sender = new Dictionary<string, IProducer>();
        public static IProducer GetSender(IConfiguration config)
        {
            //dynamic senderconfig = JObject.Parse(config);
            //string type = senderconfig.type;
            //JObject configObject = senderconfig.config;
            var type = config.Type;
            switch (type.ToLower())
            {
                case "kafkaconfig":
                    return new KafkaProducer((KafkaConfiguration)config);
                //case "firehose":
                //    return new FireHoseSender(configObject.ToObject<SenderConfiguration>());
                default:
                    return null;
            } 
        }

        //public static ISender GetSender(IConfiguration configuration)
        //{
        //    if(configuration is KafkaConfiguration)
        //    {
                
        //    } 
        //}
    }
}