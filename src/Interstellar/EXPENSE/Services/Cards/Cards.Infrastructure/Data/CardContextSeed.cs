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
                    CardExpieryDate=DateTime.ParseExact("31/12/2022", "dd/MM/yyyy", null).Date,
                    CardStatementDate=DateTime.ParseExact("01/01/2022", "dd/MM/yyyy", null).Date,
                    CardTotalExpenditure=1,
                    CardCurrentMonthExpenditure=0,
                    CardNextMonthExpenditure=0,
                    CardNextStatementDate=DateTime.ParseExact("01/02/2022", "dd/MM/yyyy", null).Date,
                    CardTransactions=new List<string>(),
                    GracePeriod=50,
                    CreatedDate=DateTime.Now.Date,
                    LastModifiedBy="SUBHASISH",
                    LastModifiedDate=DateTime.Now,
                    CreatedBy="SUBHASISH"

                },
                new Card()
                {
                    CardName="ICIC CORAL CREDIT CARD",
                    CardDescription="ICICI CORAL CREDIT CARD",
                    CardNumber="1234-5678-1234-5678",
                    CardType=Domain.Enums.CardTypes.VISA,
                    CardExpieryDate=DateTime.ParseExact("31/12/2023", "dd/MM/yyyy", null).Date,
                    CardStatementDate=DateTime.ParseExact("01/01/2023", "dd/MM/yyyy", null).Date,
                    CardTotalExpenditure=1,
                    CardCurrentMonthExpenditure=0,
                    CardNextMonthExpenditure=0,
                    CardNextStatementDate=DateTime.ParseExact("01/02/2023", "dd/MM/yyyy", null).Date,
                    CardTransactions=new List<string>(),
                    GracePeriod=40,
                    CreatedDate=DateTime.Now.Date,
                    LastModifiedBy="SUBHASISH",
                    LastModifiedDate=DateTime.Now,
                    CreatedBy="SUBHASISH",
                },
            };
        }
    }
}
