using AutoMapper;

using EventBus.Messages.Events;

using Expense.Domain.Entities;

namespace Expense.API.Mapping
{
    public class ExpenseProfile:Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseEntity, CardUpdateEvent>().ReverseMap();
        }
    }
}
