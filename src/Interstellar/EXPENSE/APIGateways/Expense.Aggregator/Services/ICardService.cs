using Expense.Aggregator.Models;

namespace Expense.Aggregator.Services;

public interface ICardService
{
    Task<IEnumerable<CardModel>> GetCards();

    Task<CardModel> GetCard(string id);
}
