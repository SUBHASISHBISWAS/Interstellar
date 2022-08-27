using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expense.Application.Contracts.Persistance;
using Expense.Domain.Entities;
using Expense.Infrastructure.Persistence;

namespace Expense.Infrastructure.Repository
{
    public class ExpenseRepository : RepositoryBase<Transaction>, IExpenseRepository
    {

        public ExpenseRepository(ExpenseContext context) : base(context)
        {

        }
        public Task<IEnumerable<Transaction>> GetExpenseByExpenseType(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
