using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Cards.Application.Contracts.Persistance;
using Cards.Application.Exceptions;
using Cards.Application.Features.Cards.Command.CreateCard;
using Cards.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Cards.Application.Features.Cards.Command.UpdateCard
{
    internal class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand,string>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCardCommandHandler> _logger;

        public UpdateCardCommandHandler(ICardRepository cardRepository, IMapper mapper, ILogger<CreateCardCommandHandler> logger)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var cardToUpdate = await _cardRepository.GetByIdAsync(request.CardId);

            if (cardToUpdate==null)
            {
                _logger.LogError("Card does not Exist in database");
                throw new NotFoundException(nameof(Card), request.CardId);
            }

            _mapper.Map(request, cardToUpdate, typeof(UpdateCardCommand), typeof(Card));

            await _cardRepository.UpdateAsync(cardToUpdate);

            _logger.LogInformation($"Order {cardToUpdate} is successfully updated.");

            return cardToUpdate.CardId;
        }
    }
}
