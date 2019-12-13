using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Configuration
{
    public class KafkaConfiguration : IConfiguration
    {
        public string Endpoints { get; set; }
    }
}
