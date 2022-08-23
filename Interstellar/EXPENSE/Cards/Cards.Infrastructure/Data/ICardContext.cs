using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Entity;

using MongoDB.Driver;

namespace Cards.Infrastructure.Data
{
    public interface ICardContext
    {
        IMongoCollection<Card> Cards { get; }
    }
}
