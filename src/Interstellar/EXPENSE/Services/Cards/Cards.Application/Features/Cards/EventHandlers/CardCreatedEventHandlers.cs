
using Cards.Application.Features.Cards.Command.ResetCardBillingCycle;
using Cards.Domain.Entity;

using MediatR;

using PubSub;

namespace Cards.Application.Features.Cards.EventHandlers
{
    public class CardCreatedEventHandlers
    {
        private readonly IMediator _mediator;

        public CardCreatedEventHandlers(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Initilize();
        }

        private void Initilize()
        {
            Hub hub = Hub.Default;
            hub.Subscribe<Card>(async (card) =>
            {
                var resetCardBillingCycleCommand = new ResetCardBillingCycleCommand();
                var cards = await _mediator.Send(resetCardBillingCycleCommand);
            });
        }
    }
}
