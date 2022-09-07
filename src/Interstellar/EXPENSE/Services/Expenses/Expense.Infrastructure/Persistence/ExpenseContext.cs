
using Expense.Domain.Common;
using Expense.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Expense.Infrastructure;

public class ExpenseContext : DbContext
{
    public DbSet<ExpenseEntity>? Transactions { get; set; }

    public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
    {

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "subhasish";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "subhasish";
                    break;
                default:
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
