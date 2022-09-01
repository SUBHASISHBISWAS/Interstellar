using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Application.Features.Cards.Command.UpdateCard;
using FluentValidation;

namespace Cards.Application.Features.Cards.Command.UpdateCardTotalExpenditure
{
    public class UpdateCardTotalExpenditureCommandValidator : AbstractValidator<UpdateCardTotalExpenditureCommand>
    {
        public UpdateCardTotalExpenditureCommandValidator()
        {
            RuleFor(p => p.CardId).NotEmpty().WithMessage("{CardId} is Required").NotNull().WithMessage("{CardId} should not be Null");

            RuleFor(p => p.CardSwipeAmount).NotEmpty().WithMessage("{CardTotalTotalExpenditure} is Required").GreaterThan(0).WithMessage("{CardTotalTotalExpenditure} should not be Empty");
        }
    }
}
