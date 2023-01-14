using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace CardType.Application.Features.CardType.Commands.UpdateCardType
{
    internal class UpdateCardTypeCommandValidator: AbstractValidator<UpdateCardTypeCommand>
    {
        public UpdateCardTypeCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{Name} is Required").NotNull().MaximumLength(20).WithMessage("{Name} must not exceed 20 Character");
        }
    }
}
