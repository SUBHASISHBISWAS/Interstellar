using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Enums;

using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCards
{
    public class GetCardListByCardTypeQuery:IRequest<List<CardVm>>
    {
        public CardTypes CardTypes { get; set; }

        public GetCardListByCardTypeQuery(CardTypes cardTypes)
        {
            CardTypes = cardTypes;
        }
    }
}
