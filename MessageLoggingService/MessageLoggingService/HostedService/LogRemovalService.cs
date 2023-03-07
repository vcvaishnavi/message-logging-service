using MessageLoggingService.Contracts;

namespace MessageLoggingService.HostedService
{
    public class LogRemovalService
    {
        private readonly ILogRepository _logRepository;

        public LogRemovalService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task LogRemovalAsync()
        {
            await Task.Delay(100);
            _logRepository.deleteMessage();
           
        }
    }
}
