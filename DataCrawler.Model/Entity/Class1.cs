using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Model.Entity
{
    public class KafkaClientSetting
    {
        public string KafkaEndpoit { get; set; }

        public string NumberOfPartitions { get; set; }

        public string Topic { get; set; }

        /// <summary>
        ///Type of acknowldgement required for the Message Exchange 
        /// </summary>
        //public Acknowledgement Acknowledgement { get; set; }

        public string Acknowledgement { get; set; }

        /// <summary>
        /// Maximum Number of Retries that the Producer should make before returning an exception
        /// </summary>
        public int MaximumNumberOfRetries { get; set; }

        public int BatchNumber { get; set; }

        /// <summary>
        /// Amount of time that a producer should wait for additional message before sending a current batch. 
        /// </summary>
        public double LingerInMilliSecond { get; set; }

        public int BackPressureThreshold { get; set; }

        public int MaximumKilloByteBuffering { get; set; }

        public int MaximumMessageBuffering { get; set; }
    }

    public class Message
    {
        public string Topic { get; set; }
        public string Payload { get; set; }
    }
}
