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
            bool isCardExist = cardCollection.Find(p => true).Any();
            if (!isCardExist)
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
                    CardName="HDFC GLOBAL CREDIT CARD",
                    CardDescription="HDFC GLOBAL CREDIT CARD",
                    CardNumber="1234-5678-1234-5678",
                    CardType=Domain.Enums.CardTypes.VISA,
                    CardExpieryDate=Convert.ToDateTime("31-12-2022").Date,
                    CardStatementDate=Convert.ToDateTime("01-01-2022").Date,
                    CreatedDate=DateTime.Now.Date,
                    LastModifiedBy="SUBHASISH",
                    LastModifiedDate=DateTime.Now,
                    CreatedBy="SUBHASISH",
                },
                new Card()
                {
                    CardName="ICIC CORAL CREDIT CARD",
                    CardDescription="ICICI CORAL CREDIT CARD",
                    CardNumber="1234-5678-1234-5678",
                    CardType=Domain.Enums.CardTypes.VISA,
                    CardExpieryDate=Convert.ToDateTime("31-12-2023").Date,
                    CardStatementDate=Convert.ToDateTime("01-01-2023").Date,
                    CreatedDate=DateTime.Now.Date,
                    LastModifiedBy="SUBHASISH",
                    LastModifiedDate=DateTime.Now,
                    CreatedBy="SUBHASISH",
                },
            };
        }
    }
}
