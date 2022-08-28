using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Cards.Application.Contracts.Persistance;
using Cards.Domain.Entity;
using Cards.Domain.Enums;
using Cards.Infrastructure.Data;

using MongoDB.Driver;

namespace Cards.Infrastructure.Repository
{
    internal class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(ICardContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Card>> GetAllCards(CardTypes cardTypes)
{
            FilterDefinition<Card> filter = Builders<Card>.Filter.Eq(p => p.CardType, cardTypes);
            return await _context.Cards.Find(filter).ToListAsync();
        }
    }
}
