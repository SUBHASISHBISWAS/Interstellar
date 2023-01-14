using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using CardType.Application.Contracts.Persistance;
using CardType.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace CardType.Application.Features.CardType.Commands.CreateCardType
{
    public class CreateCardTypeCommandHandler : IRequestHandler<CreateCardTypeCommand, string>
    {
        private readonly ICardTypeRepository _cardTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCardTypeCommandHandler> _logger;

        public CreateCardTypeCommandHandler(ICardTypeRepository cardTypeRepository, IMapper mapper, ILogger<CreateCardTypeCommandHandler> logger)
        {
            _cardTypeRepository = cardTypeRepository ?? throw new ArgumentNullException(nameof(cardTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(CreateCardTypeCommand request, CancellationToken cancellationToken)
        {
            var cardTypeEntity = _mapper.Map<ExpenseCardType>(request);
            var newCardType = await _cardTypeRepository.AddAsync(cardTypeEntity);

            _logger.LogInformation($"CardType {newCardType.Id} is successfully created");
            return newCardType.Id!;
        }
    }
}
