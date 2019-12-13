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
        static JObject _defaultKafkaClientSetting = JObject.Parse(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")));
        public IProducer<TKey, TValue> CreateClient<TKey, TValue>(SenderConfiguration senderConfiguration)
        {
            ProducerConfig producerConfig = GetProducerConfig(senderConfiguration);
            return new ProducerBuilder<TKey, TValue>(producerConfig).Build();
        }

        private static ProducerConfig GetProducerConfig(SenderConfiguration senderConfiguration)
        {
            return new ProducerConfig
            {
                BootstrapServers = string.IsNullOrEmpty(senderConfiguration.Endpoints) ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.Endpoints).Value<string>() : senderConfiguration.Endpoints,
                MessageSendMaxRetries = senderConfiguration.MaximumNumberOfRetries == 0? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.MaximumNumberOfRetries).Value<int>() : senderConfiguration.MaximumNumberOfRetries,
                //producerConfig.RetryBackoffMs
                Acks = GetAcknowledgement(senderConfiguration.Acknowledgement), //config.Acknowledgement;
                BatchNumMessages = senderConfiguration.BatchNumber == 0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.BatchNumber).Value<int>() : senderConfiguration.BatchNumber,
                LingerMs = senderConfiguration.LingerInMilliSecond == 0.0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.LingerInMilliSecond).Value<double>() : senderConfiguration.LingerInMilliSecond,
                QueueBufferingBackpressureThreshold = senderConfiguration.BackPressureThreshold == 0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.BackPressureThreshold).Value<int>() : senderConfiguration.BackPressureThreshold,  // Size transmitted from broker and waiting in queue
                QueueBufferingMaxKbytes = senderConfiguration.MaximumKilloByteBuffering == 0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.MaximumKilloByteBuffering).Value<int>() : senderConfiguration.MaximumKilloByteBuffering,     //For the size outstanding to be sent to producer queue
                QueueBufferingMaxMessages = senderConfiguration.MaximumMessageBuffering == 0 ? _defaultKafkaClientSetting.SelectToken(Constants.KafkaDefaultConfiguration.MaximumMessageBuffering).Value<int>() : senderConfiguration.MaximumMessageBuffering
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
