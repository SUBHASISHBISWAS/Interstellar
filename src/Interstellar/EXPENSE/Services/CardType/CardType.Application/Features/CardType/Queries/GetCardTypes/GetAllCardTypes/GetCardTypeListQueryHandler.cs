using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using CardType.Application.Contracts.Persistance;
using CardType.Application.Features.CardType.Queries.GetAllCardTypes;
using CardType.Application.Features.CardType.Queries.GetCardTypes.ViewModel;

using MediatR;

namespace CardType.Application.Features.CardType.Queries.GetCardTypes.GetAllCardTypes
{
    public class GetCardTypeListQueryHandler : IRequestHandler<GetCardTypeListQuery, List<ExpenseCardTypeVm>>
    {
        private readonly ICardTypeRepository _cardTypeRepository;
        private readonly IMapper _mapper;

        public GetCardTypeListQueryHandler(ICardTypeRepository cardTypeRepository, IMapper mapper)
        {
            _cardTypeRepository = cardTypeRepository ?? throw new ArgumentNullException(nameof(cardTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ExpenseCardTypeVm>> Handle(GetCardTypeListQuery request, CancellationToken cancellationToken)
        {
            var cardTypeList = await _cardTypeRepository.GetAllCardTypes();
            return _mapper.Map<List<ExpenseCardTypeVm>>(cardTypeList);
        }
    }
}
