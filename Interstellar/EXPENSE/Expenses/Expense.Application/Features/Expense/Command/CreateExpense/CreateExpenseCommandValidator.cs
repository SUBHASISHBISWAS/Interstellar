using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Expense.Application.Features.Expense.Command.CreateExpense
{
    internal class CreateExpenseCommandValidator:AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator()
        {
            RuleFor(p=>p.TransactionAmout).NotEmpty().WithMessage("{TransactionAmout} is Required");

            RuleFor(p => p.TransactionCard).NotEmpty().WithMessage("{TransactionCard} is Required");

            RuleFor(p => p.TransactionType).NotEmpty().WithMessage("{TransactionType} is Required");
        }
    }
}
