﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expense.Domain.Entities;

namespace Expense.Application.Contracts.Persistance
{
    public interface IExpenseRepository : IAsyncRepository<ExpenseEntity>
    {
        Task<IEnumerable<ExpenseEntity>> GetExpenseByExpenseType(string userName);
    }
}
