using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Domain.Entity;

using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

namespace CardType.Infrastructure.Data
{
    public class CardTypeContext:ICardTypeContext
    {
        
        public CardTypeContext(IConfiguration configuration)
        {
            var x = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var client = new MongoClient(x);
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            CardTypes = database.GetCollection<ExpenseCardType>(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            CardTypeContextSeed.SeedData(CardTypes);
        }
        public IMongoCollection<ExpenseCardType> CardTypes { get; }

        
    }
}
