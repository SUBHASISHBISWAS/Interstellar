using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Application.Contracts.Persistance;
using CardType.Domain.Common;
using CardType.Domain.Entity;
using CardType.Infrastructure.Data;

namespace CardType.Infrastructure.Repository
{
    public class RepositoryBase<T> : IAsyncRepository<ExpenseCardType> where T : EntityBase
    {
        protected readonly ICardTypeContext _context;

        public RepositoryBase(ICardTypeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ExpenseCardType> AddAsync(ExpenseCardType entity)
        {
            await _context.CardTypes.InsertOneAsync(entity);
            return entity;
        }
    }
}
