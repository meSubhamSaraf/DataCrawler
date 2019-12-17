using DataCrawler.Model.Entity;
using System.Threading.Tasks;

namespace DataCrawler.Model.InterFace
{
    public interface IDataDumpService
    {
        Task<MessageQueueResponse> QueueMessageAsync(MessageQueueRequest messageQueueRequest);
    }

    public interface IDataDumpValidator
    {
        bool Validate<T>(T request);
    }
        
    public interface IDataDumpEngine
    {
        Task<MessageQueueResponse> QueueMessageAsync(MessageQueueRequest messageQueueRequest);
    }

    
}
