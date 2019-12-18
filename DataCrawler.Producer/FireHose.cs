using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataCrawler.Producer
{
    public class FireHoseSender:IProducer
    {
        public FireHoseSender(SenderConfiguration senderConfiguration)
        {

        }

        public void intialiseConfig(object configObject)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(byte[] message)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(string topic, byte[] message)
        {
            throw new NotImplementedException();
        }

        Task<MessageQueueResponse> IProducer.SendAsync(string topic, byte[] message)
        {
            throw new NotImplementedException();
        }
    }
}
