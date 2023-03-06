
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

    }
}
