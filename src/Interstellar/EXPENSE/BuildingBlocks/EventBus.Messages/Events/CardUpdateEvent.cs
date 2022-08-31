using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class CardUpdateEvent:IntegrationBaseEvent
    {
        public int ExpenseId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public double ExpenseAmount { get; set; }

        public string? ExpenseType { get; set; }

        public string? ExpenseDecription { get; set; }

        public string? ExpenseCardId { get; set; }

        public DateTime ExpenseDate { get; set; }
    }
}
