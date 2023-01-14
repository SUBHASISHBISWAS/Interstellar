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

namespace CardType.Application.Features.CardType.Commands.DeleteCardType
{
    internal class DeleteCardTypeCommandHandler : IRequestHandler<DeleteCardTypeCommand>
    {
        private readonly ICardTypeRepository _cardTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCardTypeCommandHandler> _logger;

        public DeleteCardTypeCommandHandler(ICardTypeRepository cardTypeRepository, IMapper mapper, ILogger<CreateCardTypeCommandHandler> logger)
        {
            _cardTypeRepository = cardTypeRepository ?? throw new ArgumentNullException(nameof(cardTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteCardTypeCommand request, CancellationToken cancellationToken)
        {
            var cardToDelete = await _cardTypeRepository.GetByIdAsync(request.Id!);

            if (cardToDelete == null)
            {
                _logger.LogError("Card does not Exist in database");
                throw new NotFoundException(nameof(ExpenseCardType), request.Id!);
            }

            await _cardTypeRepository.DeleteAsync(cardToDelete);

            _logger.LogInformation($"Card {cardToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
