﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Cards.Application.Contracts.Persistance;

using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCards
{
    public class GetCardListQueryHandler : IRequestHandler<GetCardListByCardTypeQuery, List<CardVm>>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public GetCardListQueryHandler(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CardVm>> Handle(GetCardListByCardTypeQuery request, CancellationToken cancellationToken)
        {
            var cardList= await _cardRepository.GetAllCards(request.CardTypes);
            return _mapper.Map<List<CardVm>>(cardList);
        }
    }
}
