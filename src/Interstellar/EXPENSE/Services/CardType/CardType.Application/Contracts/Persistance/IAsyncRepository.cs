using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Domain.Common;

namespace CardType.Application.Contracts.Persistance;

public interface IAsyncRepository<T> where T : EntityBase
{
    Task<T> GetByIdAsync(string id);

    Task<T> AddAsync(T entity);
    Task<bool?> UpdateAsync(T entity);
    Task<bool?> DeleteAsync(T entity);
}
