using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CardType.Application.Features.CardType.Commands.DeleteCardType
{
    public class DeleteCardTypeCommand:IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
