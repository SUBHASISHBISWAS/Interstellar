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

        public string? CardDescription { get; set; }

        public DateTime CreatdDate { get; set; }
    }
}
