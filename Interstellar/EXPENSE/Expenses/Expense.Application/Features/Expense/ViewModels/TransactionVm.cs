using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Application.Features.Expense.ViewModels
{
    public  class TransactionVm
    {
        public int TransactionId { get; set; }
        public double TransactionAmout { get; set; }

        public string? TransactionType { get; set; }

        public string? TransactionDecription { get; set; }

        public string? TransactionCard { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
