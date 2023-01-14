using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Application.Features.CardType.Queries.GetCardTypes.ViewModel;

using MediatR;

namespace CardType.Application.Features.CardType.Queries.GetAllCardTypes;

public class GetCardTypeListQuery :IRequest<List<ExpenseCardTypeVm>>
{

}
