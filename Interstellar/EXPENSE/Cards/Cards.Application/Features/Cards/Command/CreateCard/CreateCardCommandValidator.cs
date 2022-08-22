using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Cards.Application.Features.Cards.Command.CreateCard
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(p => p.CardName).NotEmpty().WithMessage("{CardName} is Required").NotNull().MaximumLength(20).WithMessage("{CardName} must not exceed 20 Character");
        }

    }
}
