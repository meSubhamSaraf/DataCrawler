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

        public async Task SendAsync(byte[] message)
        {
            var producer = _kafkaClientProvider.CreateClient<Null, byte[]>();
            try
            {
                //TODO: Also implement this method with specified partition.
                var recordMetaData = await producer.ProduceAsync("Greeting", new Message<Null, byte[]> { Value = message });
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

        public Task SendAsync(string topic, byte[] message)
        {
            throw new NotImplementedException();
        }
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

}
