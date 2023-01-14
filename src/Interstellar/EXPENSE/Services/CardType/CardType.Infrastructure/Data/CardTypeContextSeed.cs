using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Domain.Entity;

using MongoDB.Driver;

namespace CardType.Infrastructure.Data
{
    public class CardTypeContextSeed
    {
        public static void SeedData(IMongoCollection<ExpenseCardType> cardCollection)
        {
            bool isCardTypeExist = cardCollection.Find(p => true).Any();
            if (!isCardTypeExist)
            {
                cardCollection.InsertManyAsync(GetPreconfiguredCardType());
            }
        }
        private static IEnumerable<ExpenseCardType> GetPreconfiguredCardType()
        {
            return new List<ExpenseCardType>()
            {
                new ExpenseCardType()
                {
                    
                    Name="VISA",
                    Description="Visa Card Type",
                    CreatedDate=DateTime.Now,
                    LastModifiedBy="SUBHASISH",
                    LastModifiedDate=DateTime.Now,
                    CreatedBy="SUBHASISH"
                },
                new ExpenseCardType()
                {

                    Name="AMEX",
                    Description="Amex Card Type",
                    CreatedDate=DateTime.Now,
                    LastModifiedBy="SUBHASISH",
                    LastModifiedDate=DateTime.Now,
                    CreatedBy="SUBHASISH"
                }
            };
        }
    }
}
