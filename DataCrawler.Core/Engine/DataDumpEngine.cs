using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataCrawler.Core.Engine
{
    public class DataDumpEngine : IDataDumpEngine
    {
        private readonly IConfigurationBuilder _configurationResolver;
        private IProducerWarehouse _producerWarehouse;

        public DataDumpEngine(IConfigurationBuilder configurationResolver, IProducerWarehouse producerWarehouse)
        {
            _configurationResolver = configurationResolver;
            _producerWarehouse = producerWarehouse;
        }

        public Task<MessageQueueResponse> QueueMessageAsync(MessageQueueRequest messageQueueRequest)
        {
            IProducer producer = _producerWarehouse.GetProducer(messageQueueRequest.UserId, messageQueueRequest.StreamName);
            return producer.SendAsync(messageQueueRequest.StreamName, Encoding.ASCII.GetBytes(messageQueueRequest.Message));

        }
    }
}
