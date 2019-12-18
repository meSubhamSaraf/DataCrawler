using DataCrawler.Model.InterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Core.Service
{
    public class ProducerWarehouse : IProducerWarehouse
    {
        private Dictionary<string, IDictionary<string, IProducer>> _userToProducerMapping = new Dictionary<string, IDictionary<string, IProducer>>();
        private Dictionary<string, IDictionary<string, IConfiguration>> _userToConfigMapping = new Dictionary<string, IDictionary<string, IConfiguration>>();
        private readonly IProducerFactory _producerFactory;
        private readonly IConfigurationBuilder _configurationBuilder;

        public ProducerWarehouse(IConfigurationBuilder configurationBuilder, IProducerFactory producerFactory)
        {
            _producerFactory = producerFactory;
            _configurationBuilder = configurationBuilder;
            InitializeProducer();
        }

        public void InitializeProducer()
        {
            _userToConfigMapping = _configurationBuilder.Build();
            _userToProducerMapping = new ProducerBuilder(_producerFactory).Build(_userToConfigMapping);
        }
        public IProducer GetProducer(string userId, string streamName)
        {
            return _userToProducerMapping[userId][streamName];
        }
    }

    public class ProducerBuilder
    {
        private Dictionary<string, IDictionary<string, IProducer>> _userMappedProducers = new Dictionary<string, IDictionary<string, IProducer>>();
        private IProducerFactory _producerFactory;
        public ProducerBuilder(IProducerFactory producerFactory)
        {
            _producerFactory = producerFactory;
        }

        public Dictionary<string, IDictionary<string, IProducer>> Build(Dictionary<string, IDictionary<string, IConfiguration>> userMappedConfiguration)
        {
            foreach (var userConfigurations in userMappedConfiguration)
            {
                var streamToConfigurationMappings = userConfigurations.Value;
                _userMappedProducers.Add(userConfigurations.Key, GetStreamsToProducerMappingMappings(streamToConfigurationMappings));
            }

            return _userMappedProducers;
        }

        private Dictionary<string, IProducer> GetStreamsToProducerMappingMappings(IDictionary<string, IConfiguration> streamToConfigurationMappings)
        {
            Dictionary<string, IProducer> _streamToProducerMapping = new Dictionary<string, IProducer>();
            foreach(var streamToConfigurationMapping in streamToConfigurationMappings)
            {
                _streamToProducerMapping.Add(streamToConfigurationMapping.Key, _producerFactory.GetProducer(streamToConfigurationMapping.Value));
            }
            return _streamToProducerMapping;
        }

    }
}
