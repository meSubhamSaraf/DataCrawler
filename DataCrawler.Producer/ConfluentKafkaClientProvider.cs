using Confluent.Kafka;
using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace DataCrawler.Producer
{
    public class ConfluentKafkaClientProvider : IKafkaClientProvider
    {
        static JObject _defaultKafkaClientSetting = JObject.Parse(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "defaultKafkaSettings.json")));
        public IProducer<TKey, TValue> CreateClient<TKey, TValue>(KafkaConfiguration kafkaConfiguration)
        {
            ProducerConfig producerConfig = GetProducerConfig(kafkaConfiguration);
            return new ProducerBuilder<TKey, TValue>(producerConfig).Build();
        }

        private static ProducerConfig GetProducerConfig(KafkaConfiguration kafkaConfiguration)
        {
            return new ProducerConfig
            {
                BootstrapServers = string.IsNullOrEmpty(kafkaConfiguration.KafkaEndpoints) ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.Endpoints).Value<string>() : kafkaConfiguration.KafkaEndpoints,
                MessageSendMaxRetries = kafkaConfiguration.MaximumNumberOfRetries == 0? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.MaximumNumberOfRetries).Value<int>() : kafkaConfiguration.MaximumNumberOfRetries,
                //producerConfig.RetryBackoffMs
                Acks = GetAcknowledgement(kafkaConfiguration.Acknowledgement), //config.Acknowledgement;
                BatchNumMessages = kafkaConfiguration.BatchNumber == 0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.BatchNumber).Value<int>() : kafkaConfiguration.BatchNumber,
                LingerMs = kafkaConfiguration.LingerInMilliSecond == 0.0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.LingerInMilliSecond).Value<double>() : kafkaConfiguration.LingerInMilliSecond,
                QueueBufferingBackpressureThreshold = kafkaConfiguration.BackPressureThreshold == 0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.BackPressureThreshold).Value<int>() : kafkaConfiguration.BackPressureThreshold,  // Size transmitted from broker and waiting in queue
                QueueBufferingMaxKbytes = kafkaConfiguration.MaximumKilloByteBuffering == 0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.MaximumKilloByteBuffering).Value<int>() : kafkaConfiguration.MaximumKilloByteBuffering,     //For the size outstanding to be sent to producer queue
                QueueBufferingMaxMessages = kafkaConfiguration.MaximumMessageBuffering == 0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.MaximumMessageBuffering).Value<int>() : kafkaConfiguration.MaximumMessageBuffering
            };
        }
        private static Acks? GetAcknowledgement(Acknowledgement acknowledgement)
        {
            if (acknowledgement == Acknowledgement.NoAcknowledgement) return Acks.None;
            else if (acknowledgement == Acknowledgement.OnlyLeaderAcknowledgement) return Acks.Leader;
            else return Acks.All;

        }
    }

}
