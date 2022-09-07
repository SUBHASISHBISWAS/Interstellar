
using Expense.Application.Features.Expense.ViewModels;

using MediatR;

namespace Expense.Application.Features.Expense.Queries.GetExpenses;

public class GetExpensesQuery : IRequest<List<ExpenseVm>>
{
}
