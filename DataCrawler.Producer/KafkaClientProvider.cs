﻿using Confluent.Kafka;
using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using Microsoft.Extensions.Options;
using System;

namespace DataCrawler.Producer
{
    //public class KafkaClientProvider : IKafkaClientProvider
    //{
    //    private readonly IStaticKafkaConfigurationProvider _kafkaConfigurationProvider;
    //    private readonly AppSetting _appSetting;

    //    public KafkaClientProvider(IStaticKafkaConfigurationProvider kafkaConfigurationProvider, IOptions<AppSetting> appSettingOption)
    //    {
    //        _kafkaConfigurationProvider = kafkaConfigurationProvider;
    //        _appSetting = appSettingOption.Value;
    //    }

    //    public IProducer<TKey, TValue> CreateClient<TKey, TValue>()
    //    {
    //        var config = _kafkaConfigurationProvider.GetSettings();
    //        var producerConfig = new ProducerConfig { BootstrapServers = config.KafkaEndpoints};
    //        //producerConfig.MessageSendMaxRetries = config.MaximumNumberOfRetries;
    //        //producerConfig.RetryBackoffMs
    //        //producerConfig.Acks = Acks.All; //config.Acknowledgement;
    //        //producerConfig.BatchNumMessages = config.BatchNumber;
    //        //producerConfig.LingerMs = config.LingerInMilliSecond;
    //        //producerConfig.QueueBufferingBackpressureThreshold = config.BackPressureThreshold;  // Size transmitted from broker and waiting in queue
    //        //producerConfig.QueueBufferingMaxKbytes = config.MaximumKilloByteBuffering;     //For the size outstanding to be sent to producer queue
    //        //producerConfig.QueueBufferingMaxMessages = config.MaximumMessageBuffering;


    //        return new ProducerBuilder<TKey, TValue>(producerConfig).Build();
    //    }

    //    public IProducer<TKey, TValue> CreateClient<TKey, TValue>(SenderConfiguration clientSettings)
    //    {
    //        var config = clientSettings;
    //        var producerConfig = new ProducerConfig { BootstrapServers = config.Endpoints };
    //        //producerConfig.MessageSendMaxRetries = config.MaximumNumberOfRetries;
    //        ////producerConfig.RetryBackoffMs
    //        //producerConfig.Acks = Acks.All; //config.Acknowledgement;
    //        //producerConfig.BatchNumMessages = config.BatchNumber;
    //        //producerConfig.LingerMs = config.LingerInMilliSecond;
    //        //producerConfig.QueueBufferingBackpressureThreshold = config.BackPressureThreshold;  // Size transmitted from broker and waiting in queue
    //        //producerConfig.QueueBufferingMaxKbytes = config.MaximumKilloByteBuffering;     //For the size outstanding to be sent to producer queue
    //        //producerConfig.QueueBufferingMaxMessages = config.MaximumMessageBuffering;


    //        return new ProducerBuilder<TKey, TValue>(producerConfig).Build();
    //    }
    //}
}
