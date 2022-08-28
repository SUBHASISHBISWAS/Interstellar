﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expense.Application.Features.Expense.Command.CreateExpense;
using FluentValidation;

namespace Expense.Application.Features.Expense.Command.UpdateExpense
{
    internal class UpdateExpenseCommandValidator: AbstractValidator<CreateExpenseCommand>
    {
        public UpdateExpenseCommandValidator()
        {
            RuleFor(p => p.TransactionAmout).NotEmpty().WithMessage("{TransactionAmout} is Required");

            RuleFor(p => p.TransactionCard).NotEmpty().WithMessage("{TransactionCard} is Required");

            RuleFor(p => p.TransactionType).NotEmpty().WithMessage("{TransactionType} is Required");
        }
    }
}