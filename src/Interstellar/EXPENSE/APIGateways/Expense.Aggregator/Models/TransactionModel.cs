namespace Expense.Aggregator.Models
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public double TransactionAmout { get; set; }

        public string? TransactionType { get; set; }

        public string? TransactionDecription { get; set; }

        public string? TransactionCard { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
