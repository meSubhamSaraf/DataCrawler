using Newtonsoft.Json.Linq;

namespace DataCrawler.Configuration
{
    internal class KafkaConfigurationParser
    {
        public static KafkaConfiguration Parse(JObject config)
        {


            return new KafkaConfiguration();
        }
    }
}