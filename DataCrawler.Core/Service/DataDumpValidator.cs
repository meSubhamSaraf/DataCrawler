using DataCrawler.Model.InterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrawler.Core.Service
{
    public class DataDumpValidator : IDataDumpValidator
    {
        public bool Validate<T>(T request)
        {
            return true;
        }
    }
}
