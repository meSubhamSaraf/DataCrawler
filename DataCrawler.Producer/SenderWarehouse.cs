using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCrawler.Producer
{
    public class SenderWarehouse
    {
        private Dictionary<string,IDictionary<string,IProducer>> _userToSenderMapping = new Dictionary<string,IDictionary<string, IProducer>>();
        private Dictionary<string,IDictionary<string,IConfiguration>> _userToConfigMapping = new Dictionary<string,IDictionary<string,IConfiguration>>();
        //Dictionary<string, IConfiguration> topicToConfig = new Dictionary<string, IConfiguration>();
        public IProducer GetSender(string userId,string topic, IConfiguration configuration)
        {
            if (_userToConfigMapping.ContainsKey(userId) == false)
            {
                Dictionary<string, IConfiguration> topicToConfig = new Dictionary<string, IConfiguration>();
                topicToConfig.Add(topic, configuration);
                _userToConfigMapping.Add(userId, topicToConfig);
            }
            if(_userToConfigMapping[userId].ContainsKey(topic) == false)
            {
                _userToConfigMapping[userId].Add(topic, configuration);
            }

            if (_userToSenderMapping.ContainsKey(userId) == false)
            {
                Dictionary<string, IProducer> topicToSender = new Dictionary<string, IProducer>();
                topicToSender.Add(topic, SenderFactory.GetSender(configuration));
                _userToSenderMapping.Add(userId,topicToSender);
            }
            if(_userToSenderMapping[userId].ContainsKey(topic) == false)
            {
                _userToSenderMapping[userId].Add(topic, SenderFactory.GetSender(configuration));
            }

            return _userToSenderMapping[userId][topic];
        }

    }

    public class Sender : ISender
    {
        public async Task<MessageQueueResponse> SendAsync(MessageQueueRequest request, Dictionary<string,IDictionary<string,IConfiguration>> configuration)
        {

            SenderWarehouse senderWarehouse = new SenderWarehouse();
            IProducer sender = senderWarehouse.GetSender(request.UserId, request.StreamName, configuration[request.UserId][request.StreamName]);
            if (sender == null) return new MessageQueueResponse();
            await sender.SendAsync(request.StreamName, Encoding.ASCII.GetBytes(request.Message));

            return new MessageQueueResponse();
            //IConfiguration configuration = ConfigurationResolver.Resolve(_appSetting,userId,topic);
        }
    }

    public class ConfigurationResolver : IConfigurationResolver
    {
        private Dictionary<string,IDictionary<string, IConfiguration>> _userToConfigurationMapper = new Dictionary<string,IDictionary<string,IConfiguration>>();

        public  Dictionary<string, IDictionary<string, IConfiguration>> Resolve(AppSetting appSetting,string userId,string topic)
        { 
            foreach(var user in appSetting.users)
            {
                switch (user.type.ToLower())
                {
                    case "kafkaconfig":
                        _userToConfigurationMapper.Add(user.id,new KafkaConfigParser().Parse(user.configs,user.type));
                        break;
                }
            }

            return _userToConfigurationMapper;
        }
        
    }

    public class KafkaConfigParser
    {
        public Dictionary<string,IConfiguration> Parse(Config[] configs,string type)
        {
            Dictionary<string, IConfiguration> streamToConfigMapping = new Dictionary<string, IConfiguration>();
            foreach(var config in configs)
            {
                streamToConfigMapping.Add(config.streamname, GetKafkaConfig(config,type));
            }
            return streamToConfigMapping;
        }

        private IConfiguration GetKafkaConfig(Config config,string type)
        {
            return new KafkaConfiguration()
            {
                KafkaEndpoints = config.kafkaendpoint,
                Type = type
            };
        }
    }
}
