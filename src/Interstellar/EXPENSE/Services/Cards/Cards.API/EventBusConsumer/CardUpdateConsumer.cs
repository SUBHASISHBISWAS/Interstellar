using AutoMapper;

using Cards.Application.Features.Cards.Command.UpdateCard;

using EventBus.Messages.Events;

using MassTransit;

using MediatR;

namespace Cards.API.EventBusConsumer
{
    public class CardUpdateConsumer:IConsumer<CardUpdateEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CardUpdateConsumer> _logger;

        public CardUpdateConsumer(IMediator mediator, IMapper mapper, ILogger<CardUpdateConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<CardUpdateEvent> context)
        {
            var command = _mapper.Map<UpdateCardCommand>(context.Message);
            //var result = await _mediator.Send(command);

            //_logger.LogInformation("BasketCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", result);
            
        }
    }
}
