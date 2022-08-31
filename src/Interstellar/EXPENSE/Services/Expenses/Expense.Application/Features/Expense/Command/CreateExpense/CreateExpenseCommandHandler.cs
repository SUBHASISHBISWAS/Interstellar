using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Expense.Application.Contracts.Persistance;
using Expense.Domain.Entities;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Expense.Application.Features.Expense.Command.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ExpenseEntity>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateExpenseCommandHandler> _logger;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper, ILogger<CreateExpenseCommandHandler> logger)
        {
            _expenseRepository = expenseRepository ?? throw new ArgumentNullException(nameof(expenseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ExpenseEntity> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expenseEntity = _mapper.Map<ExpenseEntity>(request);
            var newExpense=await _expenseRepository.AddAsync(expenseEntity);
            _logger.LogInformation($"Expense {newExpense.ExpenseId} is successfully created");
            return newExpense;

        }
    }
}
