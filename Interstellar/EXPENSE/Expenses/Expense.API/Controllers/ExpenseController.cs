using System.Net;

using Expense.Application.Features.Expense.Command.CreateExpense;
using Expense.Application.Features.Expense.Command.DeleteExpense;
using Expense.Application.Features.Expense.Command.UpdateExpense;
using Expense.Application.Features.Expense.Queries.GetExpenses;
using Expense.Application.Features.Expense.ViewModels;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ExpenseController:ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetExpenses")]
        [ProducesResponseType(typeof(IEnumerable<TransactionVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionVm>>> GetAllExpenses()
        {
            var query = new GetExpensesQuery();
            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpPost(Name = "CreateExpense")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CreateExpenseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateExpense")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCard([FromBody] UpdateExpenseCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{transactionId}", Name = "DeleteExpense")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCard(int transactionId)
        {
            var command = new DeleteExpenseCommand() { TransactionId = transactionId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
