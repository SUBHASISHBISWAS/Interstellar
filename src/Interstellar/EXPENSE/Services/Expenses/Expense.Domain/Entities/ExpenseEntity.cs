using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expense.Domain.Common;

namespace Expense.Domain.Entities
{
    public class ExpenseEntity : EntityBase
    {
        public double ExpenseAmount { get; set; }

        public string? ExpenseType { get; set; }

        public string? ExpenseDecription { get; set; }

        public string? ExpenseCardId { get; set; }

        public DateTime ExpenseDate { get; set; }

    }
}
