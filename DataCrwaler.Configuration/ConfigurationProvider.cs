using System;

namespace DataCrawler.Configuration
{
    public class ConfigurationProvider
    {
        public static IConfiguration GetConfiguration(string user)
        {
            string config = "";
            //config = GetConfigFromDataSource
            IConfiguration configuration = ConfigurationParser.Parse(config);

            return configuration;
        }
    }
}
