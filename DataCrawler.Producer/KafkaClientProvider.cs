using Confluent.Kafka;
using DataCrawler.Model.InterFace;
using System;

namespace DataCrawler.Producer
{
    public class KafkaClientProvider : IKafkaClientProvider
    {
        private readonly IStaticKafkaConfigurationProvider _kafkaConfigurationProvider;

        public KafkaClientProvider(IStaticKafkaConfigurationProvider kafkaConfigurationProvider)
        {
            _kafkaConfigurationProvider = kafkaConfigurationProvider;
        }

        public IProducer<TKey, TValue> CreateClient<TKey, TValue>()
        {
            var config = _kafkaConfigurationProvider.GetSettings();
            var producerConfig = new ProducerConfig { BootstrapServers = config.KafkaEndpoit};
            //producerConfig.MessageSendMaxRetries = config.MaximumNumberOfRetries;
            ////producerConfig.RetryBackoffMs
            //producerConfig.Acks = Acks.All; //config.Acknowledgement;
            //producerConfig.BatchNumMessages = config.BatchNumber;
            //producerConfig.LingerMs = config.LingerInMilliSecond;
            //producerConfig.QueueBufferingBackpressureThreshold = config.BackPressureThreshold;  // Size transmitted from broker and waiting in queue
            //producerConfig.QueueBufferingMaxKbytes = config.MaximumKilloByteBuffering;     //For the size outstanding to be sent to producer queue
            //producerConfig.QueueBufferingMaxMessages = config.MaximumMessageBuffering;


            return new ProducerBuilder<TKey, TValue>(producerConfig).Build();
        }
    }
}
