using Confluent.Kafka;
using DataCrawler.Model.Entity;

namespace DataCrawler.Model.InterFace
{
    public interface IKafkaClientProvider
    {
        //IProducer<TKey, TValue> CreateClient<TKey, TValue>();

        IProducer<TKey, TValue> CreateClient<TKey, TValue>(SenderConfiguration clientSettings);
    }
}
