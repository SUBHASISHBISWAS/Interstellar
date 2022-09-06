using AutoMapper;

using Cards.Application.Features.Cards.Command.UpdateCard;
using Cards.Application.Features.Cards.Command.UpdateCardTransactions;

using EventBus.Messages.Events;

namespace Cards.API.Mapping
{
    public class CardProfile:Profile
    {
        public CardProfile()
        {
            CreateMap<UpdateCardTransactionCommand, CardSwipeEvent>().ReverseMap();
        }
    }
}
