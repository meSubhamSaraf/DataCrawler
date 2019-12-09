using Confluent.Kafka;
using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using System;

namespace DataCrawler.Producer
{
    public class ConfluentKafkaClientProvider : IKafkaClientProvider
    {
        public IProducer<TKey, TValue> CreateClient<TKey, TValue>(KafkaClientSetting clientSettings)
        {
            var config = clientSettings;
            ProducerConfig producerConfig = GetProducerConfig(config);
            return new ProducerBuilder<TKey, TValue>(producerConfig).Build();
        }

        private static ProducerConfig GetProducerConfig(KafkaClientSetting config)
        {
            return new ProducerConfig
            {
                BootstrapServers = config.KafkaEndpoints,
                MessageSendMaxRetries = config.MaximumNumberOfRetries == 0? 3 : config.MaximumNumberOfRetries,
                //producerConfig.RetryBackoffMs
                Acks = GetAcknowledgement(config.Acknowledgement), //config.Acknowledgement;
                BatchNumMessages = config.BatchNumber == 0 ? 10000 : config.BatchNumber,
                LingerMs = config.LingerInMilliSecond == 0.0 ? 5.0 : config.LingerInMilliSecond,
                QueueBufferingBackpressureThreshold = config.BackPressureThreshold == 0 ? 1 : config.BackPressureThreshold,  // Size transmitted from broker and waiting in queue
                QueueBufferingMaxKbytes = config.MaximumKilloByteBuffering == 0 ? 1048576 : config.MaximumKilloByteBuffering,     //For the size outstanding to be sent to producer queue
                QueueBufferingMaxMessages = config.MaximumMessageBuffering == 0 ? 100000 : config.MaximumMessageBuffering
            };
        }
        private static Acks? GetAcknowledgement(Acknowledgement acknowledgement)
        {
            if (acknowledgement == Acknowledgement.NoAcknowledgement) return Acks.None;
            else if (acknowledgement == Acknowledgement.OnlyLeaderAcknowledgement) return Acks.Leader;
            else return Acks.All;

        }

        public IProducer<TKey, TValue> CreateClient<TKey, TValue>()
        {
            throw new NotImplementedException();
        }
    }

}
