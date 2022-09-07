
using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Application.Exceptions;
using Cards.Application.Features.Cards.Command.CreateCard;
using Cards.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Cards.Application.Features.Cards.Command.DeleteCard;

public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand>
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCardCommandHandler> _logger;

    public DeleteCardCommandHandler(ICardRepository cardRepository, IMapper mapper, ILogger<CreateCardCommandHandler> logger)
    {
        _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
    {
        var cardToDelete = await _cardRepository.GetByIdAsync(request.CardId!);

        if (cardToDelete == null)
        {
            _logger.LogError("Card does not Exist in database");
            throw new NotFoundException(nameof(Card), request.CardId!);
        }

        await _cardRepository.DeleteAsync(cardToDelete);

        _logger.LogInformation($"Card {cardToDelete.CardId} is successfully deleted.");

        return Unit.Value;
    }
}
