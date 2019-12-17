using DataCrawler.Model.InterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Core.Service
{
    public class ProducerFactory : IProducerFactory
    {
        private Dictionary<string, IDictionary<string, IProducer>> _userToProducerMapping; //= new Dictionary<string, IDictionary<string, IProducer>>();
        private Dictionary<string, IDictionary<string, IConfiguration>> _userToConfigMapping; //= new Dictionary<string, IDictionary<string, IConfiguration>>();
        private readonly IConfigurationBuilder _configurationBuilder;

        ProducerFactory(IConfigurationBuilder configurationBuilder)
        {
            _configurationBuilder = configurationBuilder;
            InitializeProducer();
        }

        public void InitializeProducer()
        {
            _userToConfigMapping = _configurationBuilder.Build();
            //create producers for all the configs and store it in the dictionary;
            _userToProducerMapping = 
        }
        public IProducer GetProducer(string userId, string streamName)
        {
            return _userToProducerMapping[userId][streamName];
        }
    }

    public class ProducerBuilder
    {

        private Dictionary<string, IDictionary<string, IProducer>> _userMappedProducers = new Dictionary<string, IDictionary<string, IProducer>>();
        public Dictionary<string, IDictionary<string, IProducer>> Build(Dictionary<string, IDictionary<string, IConfiguration>> userMappedConfiguration)
        {
            foreach(var userConfigurations in userMappedConfiguration)
            {
                var streamToConfigurationMappings = userConfigurations.Value;
                foreach(var streamToConfigurationMapping in streamToConfigurationMappings)
                {
                    if (_userMappedProducers.ContainsKey(userConfigurations.Key))
                    {
                        _userMappedProducers[userConfigurations.Key][]
                    }
                }
            }
        }
    }
}
