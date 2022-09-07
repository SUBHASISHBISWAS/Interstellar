
using System.Diagnostics;

using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Application.Exceptions;
using Cards.Application.Utility;
using Cards.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Cards.Application.Features.Cards.Command.CreateCard;

public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, string>
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCardCommandHandler> _logger;
    private readonly IMediator _mediator;
    public CreateCardCommandHandler(ICardRepository cardRepository, IMapper mapper, ILogger<CreateCardCommandHandler> logger, IMediator mediator)
    {
        _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<string> Handle(CreateCardCommand request, CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<Card>(request);


        //Calculate Due Date and Next Statment Date
        cardEntity.CreatedBy = "SUBHASISH";
        cardEntity.CreatedDate = DateTime.Now;
        cardEntity.CardDueDate = request.CardStatementDate.AddDays(+request.GracePeriod).AddMonths(-1);
        cardEntity.CardNextStatementDate = request.CardStatementDate.AddMonths(1);
        var statementDiffDays = (cardEntity.CardNextStatementDate - request.CardStatementDate).TotalDays;
        cardEntity.CardTransactions = new List<string>();
        var newCard = await _cardRepository.AddAsync(cardEntity);

        _logger.LogInformation($"Card {newCard.CardId} is successfully created");

        CardUpdateTrigger cardUpdateTrigger = new CardUpdateTrigger(newCard.CardId!, 0, 0, 60);
        cardUpdateTrigger.OnTimeTriggered += CardUpdateTrigger_OnTimeTriggered;

        return newCard.CardId!;
    }

    private async void CardUpdateTrigger_OnTimeTriggered(string cardId)
    {

        var cardToUpdate = await _cardRepository.GetByIdAsync(cardId);

        if (cardToUpdate == null)
        {
            _logger.LogError("Card does not Exist in database");
            throw new NotFoundException(nameof(Card), cardId);
        }

        cardToUpdate.LastModifiedBy = Process.GetCurrentProcess().ProcessName;
        cardToUpdate.LastModifiedDate = DateTime.Now;
        cardToUpdate.CardStatementDate = cardToUpdate.CardNextStatementDate;
        cardToUpdate.CardDueDate = cardToUpdate.CardStatementDate.AddDays(+cardToUpdate.GracePeriod).AddMonths(-1);
        cardToUpdate.CardNextStatementDate = cardToUpdate.CardStatementDate.AddMonths(1);
        cardToUpdate.CardCurrentMonthExpenditure = cardToUpdate.CardNextMonthExpenditure;
        cardToUpdate.CardNextMonthExpenditure = 0;

        await _cardRepository.UpdateAsync(cardToUpdate);

        _logger.LogInformation($"Order {cardToUpdate} is successfully updated.");
    }
}
