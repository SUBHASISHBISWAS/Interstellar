﻿
using Cards.Application.Features.Cards.Queries.GetCards.ViewModel;

using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCards.GetCardById;

public class GetCardByIdQuery : IRequest<CardVm>
{
    public string Id { get; set; }

    public GetCardByIdQuery(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}
