using MessageLoggingService.Models;

namespace MessageLoggingService.Contracts
{
    public interface ILogRepository
    {
        /// <summary>
        /// Reads log messages from log object after it filters by logId and max age.
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        public List<Log> getLog(int logId);
        /// <summary>
        /// Adds a message to the Log.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logId"></param>
        /// <param name="message"></param>
        public void addMessage(string name, int logId, string message);
        /// <summary>
        /// Updates the setMaxAge variable.
        /// </summary>
        /// <param name="maxAge"></param>
        public void setMaxAge(int maxAge);
        /// <summary>
        /// Reads the serivce state for this log service. The parameters are mentioned in the Service state entity.
        /// </summary>
        /// <returns></returns>
        public ServiceState getServiceState();
        /// <summary>
        /// Deletes message whose time span is more than max age.
        /// </summary>
        public void deleteMessage();
        /// <summary>
        /// Sets the timer Interval variable.
        /// </summary>
        /// <param name="timerInterval"></param>
        public void setTimerInterval(int timerInterval);
    }
}
