using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Expense.Application.Features.Expense.Command.DeleteExpense
{
    public class DeleteExpenseCommand:IRequest
    {
        public int TransactionId { get; set; }
    }
}
