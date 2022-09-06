using AutoMapper;

using Cards.Application.Features.Cards.Command.UpdateCard;
using Cards.Application.Features.Cards.Command.UpdateCardTransactions;

using EventBus.Messages.Events;

using MassTransit;

using MediatR;

namespace Cards.API.EventBusConsumer
{
    public class CardTotalExpenditureUpdateConsumer:IConsumer<CardSwipeEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CardTotalExpenditureUpdateConsumer> _logger;

        public CardTotalExpenditureUpdateConsumer(IMediator mediator, IMapper mapper, ILogger<CardTotalExpenditureUpdateConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<CardSwipeEvent> context)
        {
            var command = _mapper.Map<UpdateCardTransactionCommand
                >(context.Message);
            var result = await _mediator.Send(command);
            _logger.LogInformation("CardUpdate Event consumed successfully. Updated Card Id : {newOrderId}", result);
            
        }
    }
}
