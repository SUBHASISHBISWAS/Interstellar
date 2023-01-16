using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Application.Contracts.Persistance;
using CardType.Domain.Common;
using CardType.Domain.Entity;
using CardType.Infrastructure.Data;

using MongoDB.Driver;

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

        public async Task<bool?> DeleteAsync(ExpenseCardType entity)
        {
            FilterDefinition<ExpenseCardType> filter = Builders<ExpenseCardType>.Filter.Eq(p => p.Id, entity.Id);

            var deleteResult = await _context.CardTypes.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
        public async Task<IEnumerable<ExpenseCardType>> GetAllAsync()
        {
            return await _context.CardTypes.Find(prop => true).ToListAsync();
        }
        public async Task<ExpenseCardType> GetByIdAsync(string id)
        {
            return await _context.CardTypes.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool?> UpdateAsync(ExpenseCardType entity)
        {
            var updateResult = await _context.CardTypes.ReplaceOneAsync(filter: p => p.Id == entity.Id, replacement: entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
