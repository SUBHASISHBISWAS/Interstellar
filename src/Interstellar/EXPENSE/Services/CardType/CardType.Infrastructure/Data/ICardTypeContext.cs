using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Domain.Entity;

using MongoDB.Driver;

namespace CardType.Infrastructure.Data
{
    public interface ICardTypeContext
    {
        IMongoCollection<ExpenseCardType> CardTypes { get; }
    }
}
