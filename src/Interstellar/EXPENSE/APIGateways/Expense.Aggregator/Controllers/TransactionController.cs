using System.Net;

using Expense.Aggregator.Models;
using Expense.Aggregator.Services;

using Microsoft.AspNetCore.Mvc;

namespace Expense.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController
    {

        private readonly ICardService _cardService;
        private readonly IExpenseService _expenseService;

        public TransactionController(ICardService cardService, IExpenseService expenseService)
        {
            _cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
            _expenseService = expenseService ?? throw new ArgumentNullException(nameof(expenseService));
        }



        [HttpGet("{userName}", Name = "GetExpenses")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDetailModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ExpenseDetailModel>>> GetExpenses(string userName)
        {
            var expenses = new List<ExpenseDetailModel>();
            var transactions = await _expenseService.GetAllTransactions();

            transactions?.ToList().ForEach(async transaction =>
            {
                var card = await _cardService.GetCard(transaction.TransactionCard);
                expenses.Add(new ExpenseDetailModel()
                {
                    CardName=card.CardName,
                    ExpenseAmount=transaction.TransactionAmout,
                    ExpenseDate=transaction.TransactionDate,
                    ExpenseDecription=transaction.TransactionDecription,
                    ExpenseType=transaction.TransactionType
        
                });
            });


            return expenses;
            
        }
    }
}
