
using MessageLoggingService.Models;
using MessageLoggingService.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MessageLoggingServiceTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetLogTest()
        {
            var logRepository = new LogRepository();
            var x = logRepository.getLog(4);
            Assert.Empty(x);  // when file empty test passes         
        }

        [Fact]
        public void AddLogTest()
        {
            var logRepository = new LogRepository();

            logRepository.addMessage("Vaishnavi", 1, "Testing 1");
            var x= logRepository.getLog(1);
            x = logRepository.getLog(4);
            Assert.Empty(x);  // when file empty test passes         
        }

        [Fact]
        public void SetMaxSize()
        {
            var logRepository = new LogRepository();
            logRepository.setMaxAge(2);
            logRepository.addMessage("Vaishnavi", 1, "Testing 1");
            var x = logRepository.getLog(1);
            var before = DateTime.Now;
            Assert.NotEmpty(x);
            Thread.Sleep(2500);
            var Dafter= DateTime.Now;
            x = logRepository.getLog(1);
            Assert.Empty(x);  // when file empty test passes         
        }

        [Fact]
        public void DeleteMessge()
        {
            var logRepository = new LogRepository();
            logRepository.setMaxAge(2);
            logRepository.addMessage("Vaishnavi", 1, "Testing 1");
            var x = logRepository.getServiceState();
            Assert.Equal(1,x.TotalNumberOfStoredMessages);
            Thread.Sleep(2500);
            logRepository.deleteMessage();
            x = logRepository.getServiceState();
            Assert.Equal(0, x.TotalNumberOfStoredMessages);        
        }
    }
}