using DataCrawler.Producer;
using System;
using System.Text;

namespace DataCrawler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            KafkaSender sender = new KafkaSender(new KafkaClientProvider(new StaticKafkaConfigurationProvider()), new Logger());
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                sender.SendAsync(Encoding.ASCII.GetBytes(Console.ReadLine())).GetAwaiter().GetResult();
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
