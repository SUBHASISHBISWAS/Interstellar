using Expense.Aggregator.Models;

namespace Expense.Aggregator.Services
{
    public interface IExpenseService
    {
         Task<IEnumerable<ExpenseModel>> GetAllExpenses();

         Task<ExpenseModel> GetExpenseById(int id);
    }
}
