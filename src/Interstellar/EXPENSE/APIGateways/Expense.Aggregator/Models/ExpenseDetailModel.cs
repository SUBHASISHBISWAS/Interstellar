namespace Expense.Aggregator.Models
{
    public class ExpenseDetailModel
    {
        public double ExpenseAmount { get; set; }

        public string? ExpenseType { get; set; }

        public string? ExpenseDecription { get; set; }

        public string? CardName { get; set; }

        public DateTime ExpenseDate { get; set; }
    }
}
