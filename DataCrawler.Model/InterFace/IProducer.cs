﻿using DataCrawler.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataCrawler.Model.InterFace
{
    public interface IProducer
    {
        Task SendAsync(string topic, byte[] message);   
    }
}
