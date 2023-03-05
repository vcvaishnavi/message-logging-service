namespace MessageLoggingService.Models
{
    public class Log
    {
        public int logId { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public DateTime loggedAt { get; set; }

    }
}
