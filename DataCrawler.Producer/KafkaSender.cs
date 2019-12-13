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
