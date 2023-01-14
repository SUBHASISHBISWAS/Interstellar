using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Domain.Entity;

namespace CardType.Application.Contracts.Persistance;

public interface ICardTypeRepository: IAsyncRepository<ExpenseCardType>
{
    Task<IEnumerable<ExpenseCardType>> GetAllCardTypes();
}
