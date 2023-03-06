using MessageLoggingService.Contracts;

namespace MessageLoggingService.HostedService
{
    public class PeriodicHostedService : BackgroundService
    {
        private readonly TimeSpan _period = TimeSpan.FromSeconds(60);
        private readonly IServiceScopeFactory _factory;
        private readonly ILogRepository _logRepository;
        public PeriodicHostedService(IServiceScopeFactory factory, ILogRepository logRepository)
        {
            _factory = factory;
            _logRepository = logRepository;
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


            }
        }
    }
}
