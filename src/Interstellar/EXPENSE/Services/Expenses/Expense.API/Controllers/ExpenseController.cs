using System.Net;

using AutoMapper;

using EventBus.Messages.Events;

using Expense.Application.Features.Expense.Command.CreateExpense;
using Expense.Application.Features.Expense.Command.DeleteExpense;
using Expense.Application.Features.Expense.Command.UpdateExpense;
using Expense.Application.Features.Expense.Queries.GetExpenses;
using Expense.Application.Features.Expense.ViewModels;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ExpenseController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;

        public ExpenseController(IMediator mediator, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetExpenses")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ExpenseVm>>> GetAllExpenses()
        {
            var query = new GetExpensesQuery();
            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpPost(Name = "CreateExpense")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateExpense([FromBody] CreateExpenseCommand command)
        {
            var result = await _mediator.Send(command);
            var cardToUpdateMessage=_mapper.Map<CardUpdateEvent>(result);
            _publishEndpoint.Publish(cardToUpdateMessage);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateExpense")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateExpense([FromBody] UpdateExpenseCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{transactionId}", Name = "DeleteExpense")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteExpense(int transactionId)
        {
            var command = new DeleteExpenseCommand() { TransactionId = transactionId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
