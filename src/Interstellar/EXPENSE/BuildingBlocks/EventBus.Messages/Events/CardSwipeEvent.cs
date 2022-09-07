namespace EventBus.Messages.Events;

public class CardSwipeEvent : IntegrationBaseEvent
{
    public string? CardId { get; set; }

    public double CardSwipeAmount { get; set; }

    public int ExpenseId { get; set; }

    public DateTime ExpenseDate { get; set; }
}
