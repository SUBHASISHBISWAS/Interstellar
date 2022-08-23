using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCards.GetAllCards
{
    public class GetCardListQuery : IRequest<List<CardVm>>
    {
    }
}
