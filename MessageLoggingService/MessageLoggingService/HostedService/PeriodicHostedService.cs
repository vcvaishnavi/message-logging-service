using MessageLoggingService.Contracts;

namespace MessageLoggingService.HostedService
{
    public class PeriodicHostedService : BackgroundService
    {
        private TimeSpan _period;
        private readonly IServiceScopeFactory _factory;
        private readonly ILogRepository _logRepository;
        public PeriodicHostedService(IServiceScopeFactory factory, ILogRepository logRepository)
        {
            _factory = factory;
            _logRepository = logRepository;

            try
            {
                string interval = Environment.GetCommandLineArgs()[1];
                _period = TimeSpan.FromSeconds(int.Parse(interval));
            }
            catch
            {
                //If any error with the CLI arguments , default value is taken
                _period = TimeSpan.FromSeconds(60);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_period);
            while (
                !stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {

                await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                LogRemovalService deletionService = asyncScope.ServiceProvider.GetRequiredService<LogRemovalService>();
                await deletionService.LogRemovalAsync();
                Console.WriteLine($"Executed the deletion job at {DateTime.Now}...");


            }
        }
    }
}
