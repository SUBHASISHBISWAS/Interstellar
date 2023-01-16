using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Application.Contracts.Persistance;
using CardType.Domain.Entity;
using CardType.Infrastructure.Data;

namespace CardType.Infrastructure.Repository
{
    internal class CardTypeRepository : RepositoryBase<ExpenseCardType>, ICardTypeRepository
    {
        public CardTypeRepository(ICardTypeContext context) : base(context)
        {
        }
        public Task<IEnumerable<ExpenseCardType>> GetAllCardTypes()
        {
            return GetAllAsync();
        }
    }
}
