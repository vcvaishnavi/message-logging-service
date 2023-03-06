
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
        protected const string fileName = "Log.json";
      //  protected string appParameterFilename = AppDomain.CurrentDomain.BaseDirectory + "\\AppParameters.json";
      private AppParameters _appParameters;
        public LogRepository()
        {
            _appParameters = new AppParameters();
        }
        public List<Log> getLog([Required] int logId)
        {
            List<Log> source = new List<Log>();

            var json = File.ReadAllText(fileName);
            if (!(string.IsNullOrEmpty(json)))       
                    source = JsonSerializer.Deserialize<List<Log>>(json);


            if (source != null)
            {
                return source.Where(x => x.logId == logId)
                    .Where(x => (DateTime.Now- x.loggedAt).TotalSeconds < _appParameters.maxAge).ToList();                    
            }
            else
                return null;
        }

        public void addMessage([Required] string name, [Required] int logId, string message)
        {

            var logMessage = new Log { logId = logId, message = message, name = name, loggedAt = DateTime.Now };
            List<Log> source = new List<Log>();

            var json = File.ReadAllText(fileName);

            if (!(string.IsNullOrEmpty(json)))
                source = JsonSerializer.Deserialize<List<Log>>(json);

            source.Add(logMessage);
            string jsonString = JsonSerializer.Serialize(source, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(fileName, jsonString);
                

        }

        public void setMaxAge(int maxAge)
        {
            _appParameters.maxAge = maxAge;           

        }

    }
}
