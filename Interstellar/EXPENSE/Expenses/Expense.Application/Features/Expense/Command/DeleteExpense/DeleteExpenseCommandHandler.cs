using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Expense.Application.Contracts.Persistance;
using Expense.Application.Features.Expense.Command.CreateExpense;
using Expense.Application.Features.Expense.Command.UpdateExpense;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Expense.Application.Features.Expense.Command.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand>
    {

        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateExpenseCommandHandler> _logger;

        public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper, ILogger<CreateExpenseCommandHandler> logger)
        {
            _expenseRepository = expenseRepository ?? throw new ArgumentNullException(nameof(expenseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expenseToDelete = await _expenseRepository.GetByIdAsync(request.TransactionId);

            if (expenseToDelete == null)
            {
                _logger.LogError("Transation does not Exist in Database");
            }

            await _expenseRepository.DeleteAsync(expenseToDelete);

            _logger.LogInformation($"Expense  {expenseToDelete.TransactionId} is Successfully Deleted");

            return  Unit.Value;
        }
    }
}
