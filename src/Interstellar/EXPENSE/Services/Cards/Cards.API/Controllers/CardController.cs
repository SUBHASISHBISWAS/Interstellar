using System.Net;

using Cards.Application.Features.Cards.Command.CreateCard;
using Cards.Application.Features.Cards.Command.DeleteCard;
using Cards.Application.Features.Cards.Command.UpdateCard;
using Cards.Application.Features.Cards.Queries.GetCards.GetAllCards;
using Cards.Application.Features.Cards.Queries.GetCards.GetCardById;
using Cards.Application.Features.Cards.Queries.GetCards.GetCardListByCardTypeQuery;
using Cards.Application.Features.Cards.Queries.GetCards.ViewModel;
using Cards.Domain.Enums;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class CardController : ControllerBase
{
    private readonly IMediator _mediator;

    public CardController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }



    [HttpGet(Name = "GetCards")]
    [ProducesResponseType(typeof(IEnumerable<CardVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CardVm>>> GetAllCards()
    {

        var query = new GetCardListQuery();
        var cards = await _mediator.Send(query);
        return Ok(cards);
    }

    [HttpGet("GetCardById/{id}", Name = "GetCardById")]
    [ProducesResponseType(typeof(CardVm), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<CardVm>> GetCardById(string id)
    {

        var query = new GetCardByIdQuery(id);
        var cards = await _mediator.Send(query);
        return Ok(cards);
    }

    [HttpGet("GetCardsByCardType/{cardType}", Name = "GetCardsByCardType")]
    [ProducesResponseType(typeof(IEnumerable<CardVm>), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<IEnumerable<CardVm>>> GetCardsByCardType(string cardType)
    {
        Enum.TryParse<CardTypes>(cardType, true, out CardTypes CardTypeEnum);
        var query = new GetCardListByCardTypeQuery(CardTypeEnum);
        var cards = await _mediator.Send(query);
        return Ok(cards);
    }

    [HttpPost(Name = "CreateCard")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateCard([FromBody] CreateCardCommand command)
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
    public async Task<ActionResult> DeleteCard(string cardId)
    {
        var command = new DeleteCardCommand() { CardId = cardId };
        await _mediator.Send(command);
        return NoContent();
    }
}
