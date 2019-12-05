using Confluent.Kafka;

namespace DataCrawler.Model.InterFace
{
    public interface IKafkaClientProvider
    {
        IProducer<TKey, TValue> CreateClient<TKey, TValue>();
    }
}
