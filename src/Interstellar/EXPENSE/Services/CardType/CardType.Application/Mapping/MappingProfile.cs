using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using CardType.Application.Features.CardType.Commands.CreateCardType;
using CardType.Application.Features.CardType.Commands.UpdateCardType;
using CardType.Application.Features.CardType.Queries.GetCardTypes.ViewModel;
using CardType.Domain.Entity;

namespace CardType.Application.Mapping
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ExpenseCardType, ExpenseCardTypeVm>().ReverseMap();
            CreateMap<ExpenseCardType, CreateCardTypeCommand>().ReverseMap();
            CreateMap<ExpenseCardType, UpdateCardTypeCommand>().ReverseMap();
        }
    }
}
