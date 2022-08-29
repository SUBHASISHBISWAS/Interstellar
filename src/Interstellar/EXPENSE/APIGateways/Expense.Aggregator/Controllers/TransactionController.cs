using System.Net;

using Expense.Aggregator.Models;
using Expense.Aggregator.Services;

using Microsoft.AspNetCore.Mvc;

namespace Expense.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController:ControllerBase
    {

        private readonly ICardService _cardService;
        private readonly IExpenseService _expenseService;

        public TransactionController(ICardService cardService, IExpenseService expenseService)
        {
            _cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
            _expenseService = expenseService ?? throw new ArgumentNullException(nameof(expenseService));
        }



        [HttpGet(Name = "GetExpenses")]
        [ProducesResponseType(typeof(IEnumerable<TransactionModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetExpenses()
        {
            var expenses = new List<TransactionModel>();
            var transactions = await _expenseService.GetAllTransactions();

            foreach (var transaction in transactions)
            {
                var card = await _cardService.GetCard(transaction.ExpenseCardId);
                expenses.Add(new TransactionModel()
                {
                    CardName = card.CardName,
                    TransactionAmount = transaction.ExpenseAmount,
                    TransactionDate = transaction.ExpenseDate,
                    TransactionDecription = transaction.ExpenseDecription,
                    TransactionType = transaction.ExpenseType

                });
            }
            
            return Ok(expenses);



        }
    }
}
