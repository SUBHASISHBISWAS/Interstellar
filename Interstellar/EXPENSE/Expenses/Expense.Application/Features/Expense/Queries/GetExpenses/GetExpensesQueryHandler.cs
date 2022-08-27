using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Expense.Application.Contracts.Persistance;
using Expense.Application.Features.Expense.ViewModels;

using MediatR;

namespace Expense.Application.Features.Expense.Queries.GetExpenses
{
    public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, List<TransactionVm>>
    {

        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public GetExpensesQueryHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository ?? throw new ArgumentNullException(nameof(expenseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<TransactionVm>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenseList = await _expenseRepository.GetAllAsync();
            return _mapper.Map<List<TransactionVm>>(expenseList);
        }
    }
}
