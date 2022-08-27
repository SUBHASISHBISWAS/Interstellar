using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expense.Domain.Entities;

using Microsoft.Extensions.Logging;

namespace Expense.Infrastructure.Persistence
{
    public class ExpenseContextSeed
    {

        public static async Task SeedAsync(ExpenseContext orderContext, ILogger<ExpenseContext> logger)
        {
            if (!orderContext.Transactions.Any())
            {
                orderContext.Transactions.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ExpenseContextSeed).Name);
            }
        }

        private static IEnumerable<Transaction> GetPreconfiguredOrders()
        {
            return new List<Transaction>
            {
                new Transaction()
                {
                    TransactionAmout=100,
                    TransactionDate=DateTime.Now,
                    TransactionCard="6304d7cb142a8d1bc9a41916",
                    TransactionDecription="Bought Apple Phone",
                    TransactionType="Card",
                    TransactionId=1
                    
                }
            };
        }
    }
}
