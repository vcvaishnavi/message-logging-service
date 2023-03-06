namespace MessageLoggingService.Models
{
    public class AppParameters
    {
        public int maxAge { get; set; } = 60;
        /// <summary>
        /// Its the timer period interval for the log message removal job.
        /// </summary>
        public int timeInterval { get; set; } = 60;
    }
}
