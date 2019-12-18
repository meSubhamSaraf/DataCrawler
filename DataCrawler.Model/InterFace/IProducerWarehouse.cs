using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Model.InterFace
{
    public interface IProducerWarehouse
    {
        IProducer GetProducer(string userId, string streamName);
    }
}
