
using MediatR;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cards.Application.Features.Cards.Command.UpdateCardTransactions;

public class UpdateCardTransactionCommand : IRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CardId { get; set; }

    public double CardSwipeAmount { get; set; }

    public int ExpenseId { get; set; }

    public DateTime ExpenseDate { get; set; }

}
