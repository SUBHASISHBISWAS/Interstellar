using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MediatR;

namespace CardType.Application.Features.CardType.Commands.UpdateCardType
{
    public class UpdateCardTypeCommand: IRequest<string>
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
