using DataCrawler.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Model.InterFace
{
    public interface IStaticKafkaConfigurationProvider
    {
        KafkaClientSetting GetSettings();
    }
}
