using FluentValidation;

namespace Cards.Application.Features.Cards.Command.UpdateCardTransactions;

public class UpdateCardTransactionCommandValidator : AbstractValidator<UpdateCardTransactionCommand>
{
    public UpdateCardTransactionCommandValidator()
    {
        RuleFor(p => p.CardId).NotEmpty().WithMessage("{CardId} is Required").NotNull().WithMessage("{CardId} should not be Null");

        RuleFor(p => p.CardSwipeAmount).NotEmpty().WithMessage("{CardTotalTotalExpenditure} is Required").GreaterThan(0).WithMessage("{CardTotalTotalExpenditure} should not be Empty");
    }
}
