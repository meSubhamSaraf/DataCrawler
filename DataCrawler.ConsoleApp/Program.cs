using DataCrawler.Producer;
using System;

namespace DataCrawler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            KafkaSender sender = new KafkaSender(new KafkaClientProvider(new StaticKafkaConfigurationProvider()), new Logger());
            var xyz =  sender.SendAsync("Hello Kafka");

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
