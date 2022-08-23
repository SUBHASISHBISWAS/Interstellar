using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Entity;

using MongoDB.Driver;

namespace Cards.Infrastructure.Data
{
    public class CardContextSeed
    {
        public static void SeedData(IMongoCollection<Card> cardCollection)
        {
            bool isProductExist = cardCollection.Find(p => true).Any();
            if (!isProductExist)
            {
                cardCollection.InsertManyAsync(GetPreconfiguredCard());
            }
        }

        private static IEnumerable<Card> GetPreconfiguredCard()
        {
            return new List<Card>()
            {
                new Card()
                {
                    
                }
            };
        }
    }
}
