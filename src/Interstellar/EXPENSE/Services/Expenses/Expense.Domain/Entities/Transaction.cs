using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expense.Domain.Common;

namespace Expense.Domain.Entities
{
    public class Transaction : EntityBase
    {
        public double TransactionAmout { get; set; }

        public string? TransactionType { get; set; }

        public string? TransactionDecription { get; set; }

        public string? TransactionCard { get; set; }

        public DateTime TransactionDate { get; set; }

    }
}
