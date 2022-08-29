﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Expense.Application.Features.Expense.Command.CreateExpense;
using Expense.Application.Features.Expense.Command.UpdateExpense;
using Expense.Application.Features.Expense.ViewModels;
using Expense.Domain.Entities;

namespace Expense.Application.Mappings
{
    public class MappingPriofile :Profile
    {
        public MappingPriofile()
        {
            CreateMap<ExpenseEntity, TransactionVm>().ReverseMap();
            CreateMap<ExpenseEntity, CreateExpenseCommand>().ReverseMap();
            CreateMap<ExpenseEntity, UpdateExpenseCommand>().ReverseMap();

        }
    }
}
