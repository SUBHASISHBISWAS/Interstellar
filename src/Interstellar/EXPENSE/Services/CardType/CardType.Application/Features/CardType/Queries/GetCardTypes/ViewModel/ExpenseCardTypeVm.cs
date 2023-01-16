using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardType.Application.Features.CardType.Queries.GetCardTypes.ViewModel
{
    public class ExpenseCardTypeVm
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
