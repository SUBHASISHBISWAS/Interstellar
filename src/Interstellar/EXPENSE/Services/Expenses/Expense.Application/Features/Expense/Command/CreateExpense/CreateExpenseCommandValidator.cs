
using FluentValidation;

namespace Expense.Application.Features.Expense.Command.CreateExpense;

internal class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseCommandValidator()
    {
        RuleFor(p => p.ExpenseAmount).NotEmpty().WithMessage("{TransactionAmout} is Required");

        RuleFor(p => p.ExpenseCardId).NotEmpty().WithMessage("{TransactionCard} is Required");

        RuleFor(p => p.ExpenseType).NotEmpty().WithMessage("{TransactionType} is Required");
    }
}
