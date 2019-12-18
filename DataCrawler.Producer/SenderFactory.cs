using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataCrawler.Producer
{
    public class ProducerFactory : IProducerFactory
    {
        private Dictionary<string, IProducer> _sender = new Dictionary<string, IProducer>();
        public IProducer GetProducer(IConfiguration config)
        {
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
    }
}