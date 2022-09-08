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

        //public async Task DoWork(CancellationToken cancellationToken, IMediator mediator)
        //{

        //    var cardUpdateTrigger = new CardUpdateTrigger(string.Empty, second: 15);

        //    cardUpdateTrigger.OnTimeTriggered += CardUpdateTrigger_OnTimeTriggered;
        //    //while (!cancellationToken.IsCancellationRequested)
        //    //{
        //    //    try
        //    //    {

        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        _logger.LogError("The Website is Down {0}.", ex.Message);
        //    //    }
        //    //    finally
        //    //    {
        //    //        await Task.Delay(1000 * 5, cancellationToken);
        //    //    }
        //    //}
        //}

        public async Task DoWork(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var resetCardBillingCycleCommand = new ResetCardBillingCycleCommand();
            var cards = await mediator.Send(resetCardBillingCycleCommand);
        }

        private void CardUpdateTrigger_OnTimeTriggered(string obj)
        {
            Console.WriteLine();
        }
    }
}
