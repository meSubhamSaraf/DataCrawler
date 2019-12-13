using Confluent.Kafka;
using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using System;
using System.Threading.Tasks;

namespace DataCrawler.Producer
{
    public class KafkaProducer : ISender
    {
        private  IProducer<Null, byte[]> _producer;
        private static KafkaProducer _kafkaProducer;

        private ILogger _logger;
        private KafkaProducer(SenderConfiguration senderConfiguration,ILogger logger = null)
        {
            _producer = new ConfluentKafkaClientProvider().CreateClient<Null, byte[]>(senderConfiguration);
            _logger = logger == null ? new ConsoleLogger() : logger;
        }


        public static ISender GetInstance(SenderConfiguration senderConfiguration, ILogger logger = null)
        {
            if (_kafkaProducer != null)
                return _kafkaProducer;
            else
             return new KafkaProducer(senderConfiguration,logger);
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