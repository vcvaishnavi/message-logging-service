
using MessageLoggingService.Models;
using MessageLoggingService.Repositories;

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
    }
}