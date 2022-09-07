
using Expense.Domain.Entities;

using MediatR;

namespace Expense.Application.Features.Expense.Command.CreateExpense;

public class CreateExpenseCommand : IRequest<ExpenseEntity>
{

    public double ExpenseAmount { get; set; }

    public string? ExpenseType { get; set; }

    public string? ExpenseDecription { get; set; }

    public string? ExpenseCardId { get; set; }

    public DateTime ExpenseDate { get; set; }
}
