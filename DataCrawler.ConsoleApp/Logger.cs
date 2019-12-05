using DataCrawler.Model.InterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.ConsoleApp
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
