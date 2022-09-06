using AutoMapper;

using EventBus.Messages.Events;

using Expense.Domain.Entities;

namespace Expense.API.Mapping
{
    public class ExpenseProfile:Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseEntity, CardSwipeEvent>().ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.ExpenseCardId)).ForMember(dest => dest.CardSwipeAmount, opt => opt.MapFrom(src => src.ExpenseAmount)).ForMember(dest=>dest.ExpenseId,opt=>opt.MapFrom(src=>src.ExpenseId)).ForMember(dest => dest.ExpenseDate, opt => opt.MapFrom(src => src.ExpenseDate));
        }
    }
}
