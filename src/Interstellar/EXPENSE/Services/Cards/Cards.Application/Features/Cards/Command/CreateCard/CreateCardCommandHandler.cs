
using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Application.Features.Cards.Command.ResetCardBillingCycle;
using Cards.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

using PubSub;

namespace Cards.Application.Features.Cards.Command.CreateCard;

public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, string>
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCardCommandHandler> _logger;
    private readonly IMediator _mediator;
    private readonly Hub _hub;
    public CreateCardCommandHandler(ICardRepository cardRepository, IMapper mapper, ILogger<CreateCardCommandHandler> logger, IMediator mediator)
    {
        _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _hub = Hub.Default;
        _hub.Subscribe<Card>(async (card) =>
        {
            var resetCardBillingCycleCommand = new ResetCardBillingCycleCommand();
            _ = await _mediator.Send(resetCardBillingCycleCommand);
        });
    }

    public async Task<string> Handle(CreateCardCommand request, CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<Card>(request);


        //Calculate Due Date and Next Statement Date
        cardEntity.CreatedBy = "SUBHASISH";
        cardEntity.CreatedDate = DateTime.Now;
        cardEntity.CardDueDate = request.CardStatementDate.AddDays(+request.GracePeriod).AddMonths(-1);
        cardEntity.CardNextStatementDate = request.CardStatementDate.AddMonths(1);
        cardEntity.CardTransactions = new List<string>();
        var newCard = await _cardRepository.AddAsync(cardEntity);

        _logger.LogInformation($"Card {newCard.CardId} is successfully created");

        //publish Card CReated Event for Card billing cycle Reset Registration
        _hub.Publish<Card>(newCard);

        return newCard.CardId!;
    }

}
