
using Cards.Domain.Entity;

using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

namespace Cards.Infrastructure.Data;

public class CardContext : ICardContext
{
    public CardContext(IConfiguration configuration)
    {
        var x = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
        var client = new MongoClient(x);
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        Cards = database.GetCollection<Card>(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        CardContextSeed.SeedData(Cards);
    }
    public IMongoCollection<Card> Cards { get; }
}
