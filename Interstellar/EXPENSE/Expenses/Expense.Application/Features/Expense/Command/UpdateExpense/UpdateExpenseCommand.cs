using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Expense.Application.Features.Expense.Command.UpdateExpense
{
    internal class UpdateExpenseCommand : IRequest
    {
        public int TransactionId { get; set; }
        public double TransactionAmout { get; set; }

        public string? TransactionType { get; set; }

        public string? TransactionDecription { get; set; }

        public string? TransactionCard { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
