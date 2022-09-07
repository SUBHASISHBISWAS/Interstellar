
using MediatR;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cards.Application.Features.Cards.Command.DeleteCard;

public class DeleteCardCommand : IRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CardId { get; set; }
}
