using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Producer
{
    public class Constants
    {
        public static class KafkaDefaultConfiguration
        {
            public static string Endpoints = "endpoints";

            public static string NumberOfPartitions = "numberOfPartitions";

            public static string Acknowledgement = "acknowledgement";

            public static string MaximumNumberOfRetries = "maximumNumberOfRetries";

            public static string BatchNumber = "batchNumber";

            public static string LingerInMilliSecond = "lingerInMilliSecond";

            public static string BackPressureThreshold = "backPressureThreshold";

            public static string MaximumKilloByteBuffering = "maximumKilloByteBuffering";

            public static string MaximumMessageBuffering = "maximumMessageBuffering";
        }
    }
}
