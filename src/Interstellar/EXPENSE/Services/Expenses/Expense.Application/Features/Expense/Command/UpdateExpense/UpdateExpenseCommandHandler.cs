
using AutoMapper;

using Expense.Application.Contracts.Persistance;
using Expense.Application.Exceptions;
using Expense.Application.Features.Expense.Command.CreateExpense;
using Expense.Domain.Entities;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Expense.Application.Features.Expense.Command.UpdateExpense;

internal class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand>
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateExpenseCommandHandler> _logger;

    public UpdateExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper, ILogger<CreateExpenseCommandHandler> logger)
    {
        _expenseRepository = expenseRepository ?? throw new ArgumentNullException(nameof(expenseRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseToUpdate = await _expenseRepository.GetByIdAsync(request.ExpenseId);

        if (expenseToUpdate == null)
        {
            _logger.LogError("Transation does not Exist in Database");
            throw new NotFoundException(nameof(ExpenseEntity), request.ExpenseId);
        }

        _mapper.Map(request, expenseToUpdate, typeof(UpdateExpenseCommand), typeof(ExpenseEntity));

        await _expenseRepository.UpdateAsync(expenseToUpdate);

        _logger.LogInformation($"Expense  {expenseToUpdate.ExpenseId} is Successfully Updated");

        return Unit.Value;
    }
}
