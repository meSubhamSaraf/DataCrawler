using DataCrawler.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Model.InterFace
{
    public interface IConfiguration
    {
        string UserId { get; set; }

        string Type { get; set; }

    }

    public interface IConfigurationResolver
    {
        Dictionary<string, IDictionary<string, IConfiguration>> Resolve(AppSetting appSetting, string userId, string topic);
    }
}
