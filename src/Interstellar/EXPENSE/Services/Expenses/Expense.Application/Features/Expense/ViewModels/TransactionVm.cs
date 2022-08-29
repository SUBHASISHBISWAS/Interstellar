﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Application.Features.Expense.ViewModels
{
    public class ExpenseVm
    {
        public int ExpenseId { get; set; }
        public double ExpenseAmount { get; set; }

        public string? ExpenseType { get; set; }

        public string? ExpenseDecription { get; set; }

        public string? ExpenseCardId { get; set; }

        public DateTime ExpenseDate { get; set; }
    }
}
