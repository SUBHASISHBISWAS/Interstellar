using Expense.Aggregator.Extensions;
using Expense.Aggregator.Models;

namespace Expense.Aggregator.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient _httpClient;

        public ExpenseService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<TransactionModel>> GetAllTransactions()
        {
            var response = await _httpClient.GetAsync("api/v1/card");
            return await response.ReadContentAs<List<TransactionModel>>();
        }

        public async Task<TransactionModel> GetTransactionById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Catalog/{id}");
            return await response.ReadContentAs<TransactionModel>();
        }
    }
}
