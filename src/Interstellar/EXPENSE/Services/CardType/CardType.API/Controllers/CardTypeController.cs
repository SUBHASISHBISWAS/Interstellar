using System.Net;

using CardType.Application.Features.CardType.Commands.CreateCardType;
using CardType.Application.Features.CardType.Commands.DeleteCardType;
using CardType.Application.Features.CardType.Commands.UpdateCardType;
using CardType.Application.Features.CardType.Queries.GetAllCardTypes;
using CardType.Application.Features.CardType.Queries.GetCardTypes.ViewModel;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CardType.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class CardTypeController:ControllerBase
    {
        private readonly IMediator _mediator;

        public CardTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetCardTypes")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseCardTypeVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ExpenseCardTypeVm>>> GetAllCards()
        {

            var query = new GetCardTypeListQuery();
            var cards = await _mediator.Send(query);
            return Ok(cards);
        }

        [HttpPost(Name = "CreateCardType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCardType([FromBody] CreateCardTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateCardType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCardType([FromBody] UpdateCardTypeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}", Name = "DeleteCardType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCard(string id)
        {
            var command = new DeleteCardTypeCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
