using DataCrawler.Model.InterFace;
using DataCrawler.Producer;
using System;
using System.Text;

namespace DataCrawler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //KafkaSender sender = new KafkaSender(new KafkaClientProvider(new StaticKafkaConfigurationProvider()), new Logger());
            ISender sender = new Producer.Producer(new Model.Entity.KafkaClientSetting() { KafkaEndpoints = "subham-virtualbox:9092" });
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                sender.SendAsync("Greeting",Encoding.ASCII.GetBytes(Console.ReadLine())).GetAwaiter().GetResult();
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
