using DataCrawler.ConsoleApp;
using DataCrawler.Model.InterFace;
using DataCrawler.Producer;
using NUnit.Framework;
using System.Text;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ISender sender = new KafkaSender(new KafkaClientProvider(new StaticKafkaConfigurationProvider()), new Logger());
            sender.SendAsync(Encoding.ASCII.GetBytes("ABC"));
        }
        [Test]
        public void ProducerTest()
        {
            ISender sender = new Producer(new DataCrawler.Model.Entity.KafkaClientSetting() { KafkaEndpoints = "subham-virtualbox:9092" });
            sender.SendAsync("greeting",Encoding.ASCII.GetBytes("Hello"));
        }
    }
}