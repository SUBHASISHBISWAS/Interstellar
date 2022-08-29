using Expense.Aggregator.Models;

namespace Expense.Aggregator.Services
{
    public interface IExpenseService
    {
         Task<IEnumerable<ExpenseModel>> GetAllTransactions();

         Task<ExpenseModel> GetTransactionById(int id);
    }
}
