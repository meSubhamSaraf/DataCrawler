using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataCrawler.Core.Service
{
    public class DataDumpService : IDataDumpService
    {
        private readonly IDataDumpValidator _dataDumpValidator;
        private readonly IDataDumpEngine _dataDumpEngine;

        public DataDumpService(IDataDumpValidator dataDumpValidator, IDataDumpEngine dataDumpEngine)
        {
            _dataDumpValidator = dataDumpValidator;
            _dataDumpEngine = dataDumpEngine;
        }

        public async Task<MessageQueueResponse> QueueMessageAsync(MessageQueueRequest messageQueueRequest)
        {
            if (_dataDumpValidator.Validate(messageQueueRequest))
            {
                var messageQueueResponse = await _dataDumpEngine.QueueMessageAsync(messageQueueRequest);
                return messageQueueResponse;
            }
            return new MessageQueueResponse() { Errors = new List<Error>() { new Error() { Message = "Invalid Request" } } };
        }
    }
}
