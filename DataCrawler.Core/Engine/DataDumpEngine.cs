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
        private ISender _sender;

        public DataDumpEngine(IConfigurationBuilder configurationResolver, ISender sender)
        {
            _configurationResolver = configurationResolver;
            _sender = sender;
        }

        public Task<MessageQueueResponse> QueueMessageAsync(MessageQueueRequest messageQueueRequest)
        {


            //var config = JObject.Parse(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")));
            //var configuration = _configurationResolver.Build(config.ToObject<AppSetting>(), messageQueueRequest.UserId, messageQueueRequest.StreamName);
            return _sender.SendAsync(messageQueueRequest, configuration);


        }
    }
}
