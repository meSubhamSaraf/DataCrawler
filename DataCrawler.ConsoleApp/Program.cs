using DataCrawler.Model.InterFace;
using DataCrawler.Producer;
using System;
using System.Text;
using DataCrawler.Configuration;

namespace DataCrawler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {



            //var senderConfig = @"{  
            //                        'type': 'KafkaConfig',
            //                        'config': {
            //                                    'Endpoints': 'subham-virtualbox:9092',
            //                                  }
            //                     }";
            //ISender sender = ConfiGurationManager.GetSender(senderConfig);
            //while (Console.ReadKey().Key != ConsoleKey.Escape)
            //{
            //    //TODO:Remove topic from here and put it in config
            //    sender.SendAsync("Greeting",Encoding.ASCII.GetBytes(Console.ReadLine())).GetAwaiter().GetResult();
            //}

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
