using Expense.Aggregator.Enums;

namespace Expense.Aggregator.Models
{
    public class CardModel
    {
        public string? CardId { get;  set; }
        public string? CardName { get; set; }

        public CardTypes CardType { get; set; }

        public string? CardNumber { get; set; }

        public string? CardDescription { get; set; }

        public DateTime CardExpieryDate { get; set; }

        public DateTime CardStatementDate { get; set; }
    }
}
