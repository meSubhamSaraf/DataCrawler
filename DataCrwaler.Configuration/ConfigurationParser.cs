using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Configuration
{
    internal class ConfigurationParser
    {
        public static IConfiguration Parse(string configuration)
        {
            dynamic genericConfiguration = JObject.Parse(configuration);
            string type = genericConfiguration.type;
            JObject configObject = genericConfiguration.config;
            switch (type.ToLower())
            {
                case "kafkaconfig":
                    return configObject.ToObject<KafkaConfiguration>();
            }


            return null;
        }
    }
}
