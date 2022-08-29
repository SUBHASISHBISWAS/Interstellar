using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expense.Application.Features.Expense.ViewModels;

using MediatR;

namespace Expense.Application.Features.Expense.Queries.GetExpenses
{
    public class GetExpensesQuery : IRequest<List<ExpenseVm>>
    {
    }
}
