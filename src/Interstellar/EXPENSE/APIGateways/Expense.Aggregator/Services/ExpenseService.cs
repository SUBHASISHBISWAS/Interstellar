using Expense.Aggregator.Extensions;
using Expense.Aggregator.Models;

namespace Expense.Aggregator.Services;

public class ExpenseService : IExpenseService
{
    private readonly HttpClient _httpClient;

    public ExpenseService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IEnumerable<ExpenseModel>> GetAllExpenses()
    {
        HttpResponseMessage? response = await _httpClient.GetAsync("");
        return await response.ReadContentAs<List<ExpenseModel>>();
    }

    public async Task<ExpenseModel> GetExpenseById(int id)
    {
        HttpResponseMessage? response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/{id}");
        return await response.ReadContentAs<ExpenseModel>();
    }
}
