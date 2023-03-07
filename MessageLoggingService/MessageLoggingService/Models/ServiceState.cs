namespace MessageLoggingService.Models
{
    public class ServiceState
    {
        public int CurrentNumberOfStoredLogs { get; set; } = 0;
        public int MaxAge { get; set; } = 0;
        public int TotalNumberOfStoredMessages { get; set; } = 0;
        public int AverageNumberOfMessagesPerLog { get; set; } = 0;
    }
}
