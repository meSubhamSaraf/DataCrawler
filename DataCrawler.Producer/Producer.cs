using Confluent.Kafka;
using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using System;
using System.Threading.Tasks;

namespace DataCrawler.Producer
{
    public class Producer : ISender
    {

        private KafkaClientSetting _kafkaClientSetting;

        private IKafkaClientProvider _kafkaClientProvider;

        private ILogger _logger;
        public Producer(KafkaClientSetting kafkaClientSetting,ILogger logger = null)
        {
            _kafkaClientSetting = kafkaClientSetting;
            _kafkaClientProvider = new ConfluentKafkaClientProvider();
            _logger = logger == null ? new ConsoleLogger() : logger;
        }
        public async Task SendAsync(string topic, byte[] message)
        {

            var producer = _kafkaClientProvider.CreateClient<Null, byte[]>(_kafkaClientSetting);
            try
            {
                var recordMetaData = await producer.ProduceAsync(topic, new Message<Null, byte[]> { Value = message });
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
            finally
            {
                producer.Dispose();
            }
        }

        public Task SendAsync(byte[] message)
        {
            throw new NotImplementedException();
        }
    }

}
