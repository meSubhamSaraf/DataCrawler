using Confluent.Kafka;
using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using System;
using System.Threading.Tasks;

namespace DataCrawler.Producer
{
    public class KafkaProducer : IProducer
    {
        private  IProducer<Null, byte[]> _producer;
        private KafkaConfiguration _kafkaConfiguration;

        private ILogger _logger;
        public KafkaProducer(KafkaConfiguration kafkaConfiguration, ILogger logger = null)
        {
            _kafkaConfiguration = kafkaConfiguration;
            _producer = new ConfluentKafkaClientProvider().CreateClient<Null, byte[]>(kafkaConfiguration);
            _logger = logger == null ? new ConsoleLogger() : logger;
        }

        public async Task SendAsync(string topic, byte[] message)
        {
            try
            {
               var recordMetaData = await _producer.ProduceAsync(topic, new Message<Null, byte[]> { Value = message });
                _logger.Log($"Delivered '{recordMetaData.Value}' to '{recordMetaData.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                _logger.Log($"Delivery failed: {e.Error.Reason}");
            }
            catch (Exception e)
            {
                _logger.Log(e.ToString());
            }
            //finally
            //{
            //    _producer.Dispose();
            //}
        }
    }
}