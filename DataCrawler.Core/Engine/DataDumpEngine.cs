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
        private readonly IConfigurationResolver _configurationResolver;
        private ISender _sender;

        public DataDumpEngine(IConfigurationResolver configurationResolver, ISender sender)
        {
            _configurationResolver = configurationResolver;
            _sender = sender;
        }

        public Task<MessageQueueResponse> QueueMessageAsync(MessageQueueRequest messageQueueRequest)
        {


            var config = JObject.Parse(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettingsettings.json")));
            var configuration = _configurationResolver.Resolve(config.ToObject<AppSetting>(), messageQueueRequest.UserId, messageQueueRequest.StreamName);
            return _sender.SendAsync(messageQueueRequest, configuration);


        }
    }
}
