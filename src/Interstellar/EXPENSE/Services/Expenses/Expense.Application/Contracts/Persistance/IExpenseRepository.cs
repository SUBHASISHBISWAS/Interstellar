
using Expense.Domain.Entities;

namespace Expense.Application.Contracts.Persistance;

public interface IExpenseRepository : IAsyncRepository<ExpenseEntity>
{
    Task<IEnumerable<ExpenseEntity>> GetExpenseByExpenseType(string userName);
}
