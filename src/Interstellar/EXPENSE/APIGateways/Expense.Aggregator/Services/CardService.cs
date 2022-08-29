using Expense.Aggregator.Extensions;
using Expense.Aggregator.Models;

namespace Expense.Aggregator.Services
{
    public class CardService : ICardService
    {
        private readonly HttpClient _httpClient;

        public CardService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CardModel> GetCard(string id)
        {
            var response = await _httpClient.GetAsync($"/card/GetCardById/{id}");
            return await response.ReadContentAs<CardModel>();
        }

        public async Task<IEnumerable<CardModel>> GetCards()
        {
            var response = await _httpClient.GetAsync("/card");
            return await response.ReadContentAs<List<CardModel>>();
        }
    }
}
