namespace Expense.Aggregator.Models;

public class ExpenseModel
{
    public int ExpenseId { get; set; }
    public double ExpenseAmount { get; set; }

    public string? ExpenseType { get; set; }

    public string? ExpenseDecription { get; set; }

    public string ExpenseCardId { get; set; }

    public DateTime ExpenseDate { get; set; }
}
