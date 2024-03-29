﻿using System.Diagnostics;

using AutoMapper;

using Cards.Application.Contracts.Persistance;
using Cards.Application.Exceptions;
using Cards.Application.Features.Cards.Command.CreateCard;
using Cards.Domain.Entity;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Cards.Application.Features.Cards.Command.UpdateCardTransactions;

public class UpdateCardTransactionCommandHandler : IRequestHandler<UpdateCardTransactionCommand>
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCardCommandHandler> _logger;

    public UpdateCardTransactionCommandHandler(ICardRepository cardRepository, IMapper mapper, ILogger<CreateCardCommandHandler> logger)
    {
        _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateCardTransactionCommand request, CancellationToken cancellationToken)
    {
        var cardToUpdate = await _cardRepository.GetByIdAsync(request.CardId!);

        if (cardToUpdate == null)
        {
            _logger.LogError("Card does not Exist in database");
            throw new NotFoundException(nameof(Card), request.CardId!);
        }

        cardToUpdate.LastModifiedBy = Process.GetCurrentProcess().ProcessName;
        cardToUpdate.LastModifiedDate = DateTime.Now;

        cardToUpdate.CardTransactions!.Add(request.ExpenseId.ToString());

        if (request.ExpenseDate <= cardToUpdate.CardStatementDate)
        {
            cardToUpdate.CardCurrentMonthExpenditure += request.CardSwipeAmount;
        }
        else if (request.ExpenseDate > cardToUpdate.CardStatementDate && request.ExpenseDate <= cardToUpdate.CardNextStatementDate)
        {
            cardToUpdate.CardNextMonthExpenditure += request.CardSwipeAmount;
        }

        cardToUpdate.CardTotalExpenditure += request.CardSwipeAmount;


        await _cardRepository.UpdateAsync(cardToUpdate);

        _logger.LogInformation($"Order {cardToUpdate} is successfully updated.");

        return Unit.Value;
    }
}
