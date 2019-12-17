using DataCrawler.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataCrawler.Model.InterFace
{
    public interface ISender
    {
        Task<MessageQueueResponse> SendAsync(MessageQueueRequest messageQueueRequest, Dictionary<string, IDictionary<string, IConfiguration>> configuration);
    }
}
