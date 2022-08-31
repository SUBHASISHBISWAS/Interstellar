using AutoMapper;

using Cards.Application.Features.Cards.Command.UpdateCard;
using Cards.Application.Features.Cards.Command.UpdateCardTotalExpenditure;

using EventBus.Messages.Events;

namespace Cards.API.Mapping
{
    public class CardProfile:Profile
    {
        public CardProfile()
        {
            CreateMap<UpdateCardTotalExpenditureCommand, CardSwipeEvent>().ReverseMap();
        }
    }
}
