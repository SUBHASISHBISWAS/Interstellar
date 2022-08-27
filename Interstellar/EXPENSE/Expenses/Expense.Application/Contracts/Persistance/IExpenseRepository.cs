using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expense.Domain.Entities;

namespace Expense.Application.Contracts.Persistance
{
    public interface IExpenseRepository : IAsyncRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetExpenseByExpenseType(string userName);
    }
}
