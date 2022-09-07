
using Cards.Application.Contracts.Persistance;
using Cards.Domain.Common;
using Cards.Domain.Entity;
using Cards.Infrastructure.Data;

using MongoDB.Driver;

namespace Cards.Infrastructure.Repository;

public class RepositoryBase<T> : IAsyncRepository<Card> where T : EntityBase
{
    protected readonly ICardContext _context;

    public RepositoryBase(ICardContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Card> AddAsync(Card entity)
    {
        await _context.Cards.InsertOneAsync(entity);
        return entity;
    }

    public async Task<bool?> DeleteAsync(Card entity)
    {
        FilterDefinition<Card> filter = Builders<Card>.Filter.Eq(p => p.CardId, entity.CardId);

        var deleteResult = await _context.Cards.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<IEnumerable<Card>> GetAllAsync()
    {
        return await _context.Cards.Find(prop => true).ToListAsync();
    }

    public async Task<Card> GetByIdAsync(string id)
    {
        return await _context.Cards.Find(p => p.CardId == id).FirstOrDefaultAsync();
    }

    public async Task<bool?> UpdateAsync(Card entity)
    {
        var updateResult = await _context.Cards.ReplaceOneAsync(filter: p => p.CardId == entity.CardId, replacement: entity);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}
