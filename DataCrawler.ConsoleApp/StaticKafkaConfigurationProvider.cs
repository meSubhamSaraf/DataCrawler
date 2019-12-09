using DataCrawler.Model.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using DataCrawler.Model.Entity;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace DataCrawler.ConsoleApp
{
    public class StaticKafkaConfigurationProvider : IStaticKafkaConfigurationProvider
    {
        public StaticKafkaConfigurationProvider()
        {
            GetSettings();
        }

        public KafkaClientSetting GetSettings()
        {

            var  clientSetting = JObject.Parse(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")));
            return new KafkaClientSetting()
            {
                //TODO: Need to add validators and null checks for the values here
                //TODO: Need to make Constants file
                KafkaEndpoints = string.IsNullOrEmpty(clientSetting.SelectToken("KafkaEndpoint").Value<string>())? "" : clientSetting.SelectToken("KafkaEndpoint").Value<string>(),
                NumberOfPartitions = string.IsNullOrEmpty(clientSetting.SelectToken("NumberOfPartitions").Value<string>())? "1" : clientSetting.SelectToken("NumberOfPartitions").Value<string>(),
                //Acknowledgement = string.IsNullOrEmpty(clientSetting.SelectToken("Ack").Value<string>())? "all" : clientSetting.SelectToken("NumberOfPartitions").Value<string>(),
                //BackPressureThreshold = string.IsNullOrEmpty(clientSetting.SelectToken("backpressurethres").Value<string>())? 1 : clientSetting.SelectToken("backpressu").Value<int>(),
                //LingerInMilliSecond = string.IsNullOrEmpty(clientSetting.SelectToken("linger").Value<string>())? 0 : clientSetting.SelectToken("linger").Value<double>(),
                //MaximumKilloByteBuffering = string.IsNullOrEmpty(clientSetting.SelectToken("MaximumkilloBytesBuf").Value<string>())? 0 : clientSetting.SelectToken("Maximumkillobytebuff").Value<int>(),
                //BatchNumber = string.IsNullOrEmpty(clientSetting.SelectToken("batchNumber").Value<string>())? 0 : clientSetting.SelectToken("batchNumber").Value<int>(),
                //MaximumMessageBuffering = string.IsNullOrEmpty(clientSetting.SelectToken("maximummessagebuff").Value<string>())? 0 : clientSetting.SelectToken("maximumMessageBuffering").Value<int>(),
                //MaximumNumberOfRetries = string.IsNullOrEmpty(clientSetting.SelectToken("retries").Value<string>()) ? 2 : clientSetting.SelectToken("NumberOfPartitions").Value<int>(),
                //Topic = string.IsNullOrEmpty(clientSetting.SelectToken("Topic").Value<string>())? "" : clientSetting.SelectToken("Topic").Value<string>(),

            };
        }
    }
}
