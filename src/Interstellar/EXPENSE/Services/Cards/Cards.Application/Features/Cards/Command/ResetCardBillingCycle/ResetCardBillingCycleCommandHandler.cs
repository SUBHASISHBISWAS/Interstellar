using System.Diagnostics;

using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Application.Exceptions;
using Cards.Application.Utility;
using Cards.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Cards.Application.Features.Cards.Command.ResetCardBillingCycle
{
    public class ResetCardBillingCycleCommandHandler : IRequestHandler<ResetCardBillingCycleCommand, Unit>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ResetCardBillingCycleCommandHandler> _logger;


        public ResetCardBillingCycleCommandHandler(ICardRepository cardRepository, IMapper mapper, ILogger<ResetCardBillingCycleCommandHandler> logger)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(ResetCardBillingCycleCommand request, CancellationToken cancellationToken)
        {
            var cardList = await _cardRepository.GetAllAsync();

            var cardIDs = cardList.Select(c => c.CardId);
            var cardsToBeRegisteredForBillingCycleReset = cardList.Where(c => cardIDs.Except(ModelInstances.CardIdsCache).Any(x => x!.Equals(c.CardId!))).Select(x => x);

            if (cardsToBeRegisteredForBillingCycleReset.Any())
            {
                cardsToBeRegisteredForBillingCycleReset.ToList().ForEach(card =>
                {

                    var statementTimeDiff = Convert.ToInt32((card.CardNextStatementDate - card.CardStatementDate).TotalHours);
                    var cardUpdateTrigger = new CardUpdateTrigger(card.CardId!, statementTimeDiff, 0, 0);
                    cardUpdateTrigger.OnTimeTriggered += CardUpdateTrigger_OnTimeTriggered;
                    ModelInstances.CardIdsCache.Add(card.CardId!);
                });
            }

            return Unit.Value;
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

            _logger.LogInformation($"Card {cardToUpdate.CardName} is successfully updated.");
        }
    }
}
