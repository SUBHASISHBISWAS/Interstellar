using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Enums;

using MediatR;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Cards.Application.Features.Cards.Command.UpdateCard
{
    public class UpdateCardCommand:IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CardId { get; set; }

        public string? CardName { get; set; }

        public CardTypes CardType { get; set; }

        public string? CardNumber { get; set; }

        public string? CardDescription { get; set; }

        public DateTime CardExpieryDate { get; set; }

        public DateTime CardStatementDate { get; set; }
    }
}
