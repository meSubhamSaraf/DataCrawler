﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Model.InterFace
{
    public interface IProducerFactory
    {
        IProducer GetProducer(IConfiguration configuration);
    }
}
