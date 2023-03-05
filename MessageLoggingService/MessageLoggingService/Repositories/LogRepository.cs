
using MessageLoggingService.Contracts;
using MessageLoggingService.Models;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;

namespace MessageLoggingService.Repositories
{
    public class LogRepository : ILogRepository
    {
        protected const string fileName = "Log.json";
        public LogRepository()
        {
            
        }
        public List<Log> getLog(int logId)
        {
            List<Log> source = new List<Log>();

            var json = File.ReadAllText(fileName);
            if (!(string.IsNullOrEmpty(json)))       
                    source = JsonSerializer.Deserialize<List<Log>>(json);


            if (source != null)
            {
                return source.Where(x => x.logId == logId).ToList();
            }
            else
                return null;
        }

        public void addMessage(string name, int logId, string message)
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

    }
}
