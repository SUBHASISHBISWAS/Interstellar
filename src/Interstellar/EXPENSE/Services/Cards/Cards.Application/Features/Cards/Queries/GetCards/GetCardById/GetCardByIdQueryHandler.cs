
using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Application.Features.Cards.Queries.GetCards.ViewModel;

using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCards.GetCardById;

public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, CardVm>
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;

    public GetCardByIdQueryHandler(ICardRepository cardRepository, IMapper mapper)
    {
        _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CardVm> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
    {
        var card = await _cardRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CardVm>(card);
    }
}
