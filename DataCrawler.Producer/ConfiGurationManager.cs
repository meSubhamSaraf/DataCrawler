using DataCrawler.Model.InterFace;

namespace DataCrawler.Producer
{
    public class ConfiGurationManager
    {
        public static ISender GetSender(string config)
        {
            return SenderFactory.GetSender(config);
        }
    }
}