using Cards.Application.Features.Cards.Command.ResetCardBillingCycle;

using MediatR;

namespace Cards.API.HostedService
{
    public class Worker : IWorker
    {

        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var resetCardBillingCycleCommand = new ResetCardBillingCycleCommand();
            var cards = await mediator.Send(resetCardBillingCycleCommand);
        }


    }
}
