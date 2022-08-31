using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Application.Exceptions;
using Cards.Application.Features.Cards.Command.CreateCard;
using Cards.Application.Features.Cards.Command.UpdateCard;
using Cards.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Cards.Application.Features.Cards.Command.UpdateCardTotalExpenditure
{

    public class UpdateCardTotalExpenditureCommandHandler : IRequestHandler<UpdateCardTotalExpenditureCommand>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCardCommandHandler> _logger;

        public UpdateCardTotalExpenditureCommandHandler(ICardRepository cardRepository, IMapper mapper, ILogger<CreateCardCommandHandler> logger)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateCardTotalExpenditureCommand request, CancellationToken cancellationToken)
        {
            var cardToUpdate = await _cardRepository.GetByIdAsync(request.CardId);

            if (cardToUpdate == null)
            {
                _logger.LogError("Card does not Exist in database");
                throw new NotFoundException(nameof(Card), request.CardId);
            }

            cardToUpdate.CardTotalExpenditure += request.CardTotalTotalExpenditure;


            await _cardRepository.UpdateAsync(cardToUpdate);

            _logger.LogInformation($"Order {cardToUpdate} is successfully updated.");

            return Unit.Value;
        }
    }
}
