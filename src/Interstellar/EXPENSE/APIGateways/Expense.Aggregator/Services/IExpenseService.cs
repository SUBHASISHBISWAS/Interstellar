using Expense.Aggregator.Models;

namespace Expense.Aggregator.Services
{
    public interface IExpenseService
    {
         Task<IEnumerable<TransactionModel>> GetAllTransactions();

         Task<TransactionModel> GetTransactionById(int id);
    }
}
