
using Cards.Application.Features.Cards.Queries.GetCards.ViewModel;

using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCards.GetAllCards;

public class GetCardListQuery : IRequest<List<CardVm>>
{
}
