namespace Expense.Aggregator.Models;

public class TransactionModel
{
    public double TransactionAmount { get; set; }

    public string? TransactionType { get; set; }

    public string? TransactionDecription { get; set; }

    public string? CardName { get; set; }

    public DateTime TransactionDate { get; set; }
}
