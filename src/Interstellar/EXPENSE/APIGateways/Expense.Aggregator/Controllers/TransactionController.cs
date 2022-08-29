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



        [HttpGet(Name = "GetTransactions")]
        [ProducesResponseType(typeof(IEnumerable<TransactionModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetTransactions()
        {
            var tranascions = new List<TransactionModel>();

            var expenses = await _expenseService.GetAllExpenses();
            foreach (var expense in expenses)
            {
                var card = await _cardService.GetCard(expense.ExpenseCardId);
                tranascions.Add(new TransactionModel()
                {
                    CardName = card.CardName,
                    TransactionAmount = expense.ExpenseAmount,
                    TransactionDate = expense.ExpenseDate,
                    TransactionDecription = expense.ExpenseDecription,
                    TransactionType = expense.ExpenseType

                });
            }
            
            return Ok(tranascions);



        }
    }
}
