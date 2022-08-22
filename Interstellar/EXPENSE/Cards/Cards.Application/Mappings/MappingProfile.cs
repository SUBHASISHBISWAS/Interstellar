using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Cards.Application.Features.Cards.Command.CreateCard;
using Cards.Application.Features.Cards.Command.UpdateCard;
using Cards.Application.Features.Cards.Queries.GetCards;
using Cards.Domain.Entity;

namespace Cards.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardVm>().ReverseMap();
            CreateMap<Card, CreateCardCommand>().ReverseMap();
            CreateMap<Card, UpdateCardCommand>().ReverseMap();
        }
    }
}
