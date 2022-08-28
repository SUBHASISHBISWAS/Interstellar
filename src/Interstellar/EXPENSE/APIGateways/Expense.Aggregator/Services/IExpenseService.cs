using Expense.Aggregator.Models;

namespace Expense.Aggregator.Services
{
    public interface IExpenseService
    {
         Task<IEnumerable<TransactionModel>> GetAllExpenses();

         Task<TransactionModel> GetExpenseById(int id);
    }
}
