using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Cards.Application.Features.Cards.Command.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, string>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCardCommandHandler> _logger;

        public CreateCardCommandHandler(ICardRepository cardRepository, IMapper mapper, ILogger<CreateCardCommandHandler> logger)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var cardEntity = _mapper.Map<Card>(request);
            var newCard = await _cardRepository.AddAsync(cardEntity);
            _logger.LogInformation($"Card {newCard.CardId} is successfully created");
            return newCard.CardId!;
        }
    }
}
