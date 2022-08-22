using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Entity;
using Cards.Domain.Enums;

namespace Cards.Application.Contracts.Persistance
{
    public interface ICardRepository: IAsyncRepository<Card>
    {
        Task<IEnumerable<Card>> GetAllCards(CardTypes cardTypes);
    }
}
