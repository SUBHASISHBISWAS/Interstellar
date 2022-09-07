
using Cards.Domain.Entity;

using MongoDB.Driver;

namespace Cards.Infrastructure.Data;

public interface ICardContext
{
    IMongoCollection<Card> Cards { get; }
}
