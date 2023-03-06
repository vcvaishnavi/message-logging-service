﻿using MessageLoggingService.Contracts;
using MessageLoggingService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        /// Reads the log messages from the log object and filters it by log ID and MaxAge
        /// </summary>
        /// <param name="logId"></param>
        /// <returns>List of log messages after filter</returns>
        public List<Log> GetLog(int logId)
        {
           
            return (_logRepository.getLog(logId));
        }

       
        [HttpPost(Name = "AddMessage")]
        /// <summary>
        /// Adds the log message to the log object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logId"></param>
        /// <param name="message"></param>
        public void AddMessage(string name,int logId,string message)
        {

            _logRepository.addMessage(name, logId, message);
        }
       
      
        [HttpPut(Name = "SetMaxAge")]
        /// <summary>
        /// Updates the max Age variable to the given value.
        /// </summary>
        /// <param name="maxAge"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetMaxAge([Required] int maxAge)
        {
            if(maxAge == 0)
            {
                throw new ArgumentException("MaxAge cannot be 0.");
            }

            _logRepository.setMaxAge(maxAge);
        }

    }
}