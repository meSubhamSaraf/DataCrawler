using Confluent.Kafka;
using DataCrawler.Model.InterFace;
using System;
using System.Threading.Tasks;

namespace DataCrawler.Producer
{   
    public class KafkaSender : ISender
    {
        private readonly IKafkaClientProvider _kafkaClientProvider;
        private readonly ILogger _logger;

        public KafkaSender(IKafkaClientProvider kafkaClientProvider, ILogger logger)
        {
            _kafkaClientProvider = kafkaClientProvider;
            _logger = logger;
        }

        public async Task SendAsync(object message)
        {            
            using (var producer = _kafkaClientProvider.CreateClient<Null, string>())
            {
                try
                {
                    //TODO: Also implement this method with specified partition.
                    var recordMetaData = await producer.ProduceAsync("Greeting", new Message<Null, string> { Value = "Hi, Here's your message" });
                    _logger.Log($"Delivered '{recordMetaData.Value}' to '{recordMetaData.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    _logger.Log($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

    }
}
