using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Application.Features.Cards.Command.UpdateCard;

using FluentValidation;

namespace Cards.Application.Features.Cards.Command.CreateCard
{
    public class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
    {
        public UpdateCardCommandValidator()
        {
            RuleFor(p => p.CardName).NotEmpty().WithMessage("{CardName} is Required").NotNull().MaximumLength(20).WithMessage("{CardName} must not exceed 20 Character");
        }

    }
}
