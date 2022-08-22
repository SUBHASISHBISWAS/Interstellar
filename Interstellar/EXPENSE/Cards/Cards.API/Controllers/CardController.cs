using System.Net;

using Cards.Application.Features.Cards.Command.CreateCard;
using Cards.Application.Features.Cards.Command.DeleteCard;
using Cards.Application.Features.Cards.Command.UpdateCard;
using Cards.Application.Features.Cards.Queries.GetCards;
using Cards.Domain.Enums;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class CardController:ControllerBase
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{cardType}", Name = "GetCards")]
        [ProducesResponseType(typeof(IEnumerable<CardVm>), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<IEnumerable<CardVm>>> GetCardsByCardType(string cardType)
        {
            CardTypes CardTypeEnum;
            Enum.TryParse<CardTypes>(cardType, true, out CardTypeEnum);
            var query = new GetCardListQuery(CardTypeEnum);
            var cards=await _mediator.Send(query);
            return Ok(cards);
        }

        [HttpPost(Name = "CreateCard")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CreateCardCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateCard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCard([FromBody] UpdateCardCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{cardId}", Name = "DeleteCard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCard(Guid cardId)
        {
            var command = new DeleteCardCommand() { CardId = cardId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
