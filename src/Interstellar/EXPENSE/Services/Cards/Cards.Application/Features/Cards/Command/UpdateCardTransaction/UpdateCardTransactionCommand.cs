using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Cards.Application.Features.Cards.Command.UpdateCardTransactions
{
    public class UpdateCardTransactionCommand:IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CardId { get; set; }

        public double CardSwipeAmount { get; set; }

        public int ExpenseId { get; set; }

        public DateTime ExpenseDate { get; set; }

    }
}
