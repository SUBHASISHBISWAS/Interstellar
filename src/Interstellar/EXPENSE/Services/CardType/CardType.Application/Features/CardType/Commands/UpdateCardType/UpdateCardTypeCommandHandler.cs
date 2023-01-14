using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using CardType.Application.Contracts.Persistance;
using CardType.Application.Exceptions;
using CardType.Application.Features.CardType.Commands.CreateCardType;
using CardType.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace CardType.Application.Features.CardType.Commands.UpdateCardType
{
    public class UpdateCardTypeCommandHandler: IRequestHandler<UpdateCardTypeCommand, string>
    {
        private readonly ICardTypeRepository _cardTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCardTypeCommandHandler> _logger;

        public UpdateCardTypeCommandHandler(ICardTypeRepository cardTypeRepository, IMapper mapper, ILogger<UpdateCardTypeCommandHandler> logger)
        {
            _cardTypeRepository = cardTypeRepository ?? throw new ArgumentNullException(nameof(cardTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(UpdateCardTypeCommand request, CancellationToken cancellationToken)
        {
            var cardTypeToUpdate = await _cardTypeRepository.GetByIdAsync(request.Id!);

            if (cardTypeToUpdate == null)
            {
                _logger.LogError("Card Type does not Exist in database");
                throw new NotFoundException(nameof(ExpenseCardType), request.Id!);
            }

            _mapper.Map(request, cardTypeToUpdate, typeof(UpdateCardTypeCommand), typeof(ExpenseCardType));

            await _cardTypeRepository.UpdateAsync(cardTypeToUpdate);

            _logger.LogInformation($"Card Type {cardTypeToUpdate} is successfully updated.");

            return cardTypeToUpdate.Id!;
        }
    }
}
