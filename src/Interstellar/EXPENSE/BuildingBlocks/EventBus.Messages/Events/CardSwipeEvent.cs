using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class CardSwipeEvent:IntegrationBaseEvent
    {
        public string? CardId { get; set; }

        public double CardSwipeAmount { get; set; }

        public int ExpenseId { get; set; }

        public DateTime ExpenseDate { get; set; }
    }
}
