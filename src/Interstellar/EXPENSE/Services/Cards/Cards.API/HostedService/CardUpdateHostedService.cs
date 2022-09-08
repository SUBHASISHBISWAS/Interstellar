namespace Cards.API.HostedService
{
    public class CardUpdateHostedService : IHostedService
    {

        private readonly ILogger<CardUpdateHostedService> _logger;
        private readonly IWorker _worker;
        public CardUpdateHostedService(ILogger<CardUpdateHostedService> logger, IWorker worker)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _worker = worker ?? throw new ArgumentNullException(nameof(worker));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
