using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Enums;

namespace Cards.Application.Features.Cards.Queries.GetCards.ViewModel
{
    public class CardVm
    {
        public string? CardId { get; set; }

        public string? CardName { get; set; }

        public CardTypes CardType { get; set; }

        public string? CardNumber { get; set; }

        public string? CardDescription { get; set; }

        public DateTime CardExpieryDate { get; set; }

        public DateTime CardStatementDate { get; set; }

        public DateTime CardNextStatementDate { get; set; }
        public DateTime CardDueDate { get; set; }
        
        public int GracePeriod { get; set; }

        public double CardCurrentMonthExpenditure { get; set; }

        public double CardNextMonthExpenditure { get; set; }

        public double CardTotalExpenditure { get; set; }
    }
}
