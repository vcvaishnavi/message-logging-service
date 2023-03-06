using MessageLoggingService.Models;

namespace MessageLoggingService.Contracts
{
    public interface ILogRepository
    {
        public List<Log> getLog(int logId);
        public void addMessage(string name, int logId, string message);
        public void setMaxAge(int maxAge);
        public ServiceState getServiceState();
        public void deleteMessage();
    }
}
