using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Configuration
{
    public interface IConfiguration
    {
        string Endpoints { get; set; }
    }
}
