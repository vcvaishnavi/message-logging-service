
using MessageLoggingService.Contracts;
using MessageLoggingService.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;

namespace MessageLoggingService.Repositories
{
    public class LogRepository : ILogRepository
    {
     
      private AppParameters _appParameters;
        private List<Log> _logs;
        public LogRepository()
        {
            _appParameters = new AppParameters();
            _logs = new List<Log>();
        }
        public List<Log> getLog([Required] int logId)
        {
            return _logs.Where(x => x.logId == logId)
                    .Where(x => (DateTime.Now - x.loggedAt).TotalSeconds < _appParameters.maxAge).ToList();
        }

        public void addMessage([Required] string name, [Required] int logId, string message)
        {

            var logMessage = new Log { logId = logId, message = message, name = name, loggedAt = DateTime.Now };
            _logs.Add(logMessage);            

        }

        public void setMaxAge(int maxAge)
        {
            _appParameters.maxAge = maxAge;           

        }
        public ServiceState getServiceState()
        {
            var serviceState = new ServiceState();
            serviceState.MaxAge = _appParameters.maxAge;
            serviceState.TotalNumberOfStoredMessages = _logs.Count;
            serviceState.CurrentNumberOfStoredLogs = _logs.GroupBy(x => x.logId).Count();
            if(_logs.GroupBy(x => x.logId).Count() >0)
                serviceState.AverageNumberOfMessagesPerLog = _logs.Count / (_logs.GroupBy(x => x.logId).Count());
            return serviceState;
        }

        public void deleteMessage()
        {
            var x = _logs.RemoveAll(x => (DateTime.Now - x.loggedAt).TotalSeconds >= _appParameters.maxAge);
        }

    }
}
