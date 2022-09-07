
using MediatR;

namespace Expense.Application.Features.Expense.Command.DeleteExpense;

public class DeleteExpenseCommand : IRequest
{
    public int TransactionId { get; set; }
}
