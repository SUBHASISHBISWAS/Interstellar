
using Expense.Application.Contracts.Persistance;
using Expense.Domain.Entities;

namespace Expense.Infrastructure.Repository;

public class ExpenseRepository : RepositoryBase<ExpenseEntity>, IExpenseRepository
{

    public ExpenseRepository(ExpenseContext context) : base(context)
    {

    }
    public Task<IEnumerable<ExpenseEntity>> GetExpenseByExpenseType(string userName)
    {
        throw new NotImplementedException();
    }
}
