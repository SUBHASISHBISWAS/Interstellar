using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Enums;

using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCards
{
    public class GetCardListQuery:IRequest<List<CardVm>>
    {
        public CardTypes CardTypes { get; set; }

        public GetCardListQuery(CardTypes cardTypes) => CardTypes = cardTypes;
    }
}
