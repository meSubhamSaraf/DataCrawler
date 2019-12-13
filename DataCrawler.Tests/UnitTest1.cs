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

        //[Test]
        //public void ProducerTest()
        //{
        //    ISender sender = new KafkaProducer(new DataCrawler.Model.Entity.KafkaClientSetting() { KafkaEndpoints = "subham-virtualbox:9092" });
        //    sender.SendAsync("Greeting",Encoding.ASCII.GetBytes("Hello"));
        //}
    }
}