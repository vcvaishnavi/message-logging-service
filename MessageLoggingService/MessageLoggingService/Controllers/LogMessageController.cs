using MessageLoggingService.Contracts;
using MessageLoggingService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MessageLoggingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogMessageController : ControllerBase
    {
        private readonly ILogRepository _logRepository;
        public LogMessageController(ILogRepository logRepository)
        {
            _logRepository= logRepository;
        }

        [HttpGet(Name = "GetLog")]
        public List<Log> GetLog(int logId)
        {
           
            return (_logRepository.getLog(logId));
        }

        [HttpPost(Name = "AddMessage")]
        public void AddMessage(string name,int logId,string message)
        {

            _logRepository.addMessage(name, logId, message);
        }

    }
}
