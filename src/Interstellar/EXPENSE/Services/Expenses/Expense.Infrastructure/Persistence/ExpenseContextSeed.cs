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

        public static async Task SeedAsync(ExpenseContext expenseContext, ILogger<ExpenseContextSeed> logger)
        {
            if (!expenseContext.Transactions.Any())
            {
                expenseContext.Transactions.AddRange(GetPreconfiguredOrders());
                await expenseContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ExpenseContextSeed).Name);
            }
        }

        private static IEnumerable<ExpenseEntity> GetPreconfiguredOrders()
        {
            return new List<ExpenseEntity>
            {
                new ExpenseEntity()
                {
                    ExpenseAmount=100,
                    ExpenseDate=DateTime.Now,
                    ExpenseCardId="6304d7cb142a8d1bc9a41916",
                    ExpenseDecription="Bought Apple Phone",
                    ExpenseType="Card",
                    
                }
            };
        }
    }
}
