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
            var  clientSetting = JObject.Parse(File.ReadAllText(@"../../../appsettings.json"));
            return new KafkaClientSetting()
            {
                //TODO: Need to add validators and null checks for the values here
                //TODO: Need to make Constants file\
                KafkaEndpoit = clientSetting.SelectToken("KafkaEndpoint").Value<string>(),
                NumberOfPartitions = clientSetting.SelectToken("NumberOfPartitions").Value<string>(),

            };
        }
    }
}
