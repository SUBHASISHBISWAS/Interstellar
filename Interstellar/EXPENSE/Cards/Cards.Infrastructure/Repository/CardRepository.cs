using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Application.Contracts.Persistance;
using Cards.Domain.Entity;
using Cards.Domain.Enums;
using Cards.Infrastructure.Data;

namespace Cards.Infrastructure.Repository
{
    internal class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(ICardContext context) : base(context)
        {
        }

        public Task<IEnumerable<Card>> GetAllCards(CardTypes cardTypes)
        {
            throw new NotImplementedException();
        }
    }
}
