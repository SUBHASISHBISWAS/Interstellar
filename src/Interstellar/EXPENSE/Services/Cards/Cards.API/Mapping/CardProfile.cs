using AutoMapper;

using Cards.Application.Features.Cards.Command.UpdateCard;

using EventBus.Messages.Events;

namespace Cards.API.Mapping
{
    public class CardProfile:Profile
    {
        public CardProfile()
        {
            CreateMap<UpdateCardCommand, CardUpdateEvent>().ReverseMap();
        }
    }
}
