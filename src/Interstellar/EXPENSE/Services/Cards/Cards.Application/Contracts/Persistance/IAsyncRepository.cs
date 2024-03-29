﻿
using Cards.Domain.Common;

namespace Cards.Application.Contracts.Persistance;

public interface IAsyncRepository<T> where T : EntityBase
{
    Task<IEnumerable<T>> GetAllAsync();

    //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
    //								Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    //								string? includeString = null,
    //								bool disableTracking = true);
    //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
    //							   Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    //							   List<Expression<Func<T, object>>>? includes = null,
    //							   bool disableTracking = true);
    Task<T> GetByIdAsync(string id);

    Task<T> AddAsync(T entity);
    Task<bool?> UpdateAsync(T entity);
    Task<bool?> DeleteAsync(T entity);
}
