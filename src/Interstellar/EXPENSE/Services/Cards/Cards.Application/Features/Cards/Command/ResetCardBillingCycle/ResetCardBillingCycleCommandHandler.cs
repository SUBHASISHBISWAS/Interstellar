using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Application.Utility;

using MediatR;

namespace Cards.Application.Features.Cards.Command.ResetCardBillingCycle
{
    public class ResetCardBillingCycleCommandHandler : IRequestHandler<ResetCardBillingCycleCommand, Unit>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public ResetCardBillingCycleCommandHandler(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(ResetCardBillingCycleCommand request, CancellationToken cancellationToken)
        {
            var cardList = await _cardRepository.GetAllAsync();

            cardList.ToList().ForEach(card =>
            {
                var cardUpdateTrigger = new CardUpdateTrigger(card.CardId!, 0, 0, 5);
                cardUpdateTrigger.OnTimeTriggered += CardUpdateTrigger_OnTimeTriggered;
            });

            return Unit.Value;
        }

        private void CardUpdateTrigger_OnTimeTriggered(string cardId)
        {
            Console.WriteLine();
        }
    }
}
