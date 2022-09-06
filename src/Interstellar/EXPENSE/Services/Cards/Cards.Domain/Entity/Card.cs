using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Common;
using Cards.Domain.Enums;

namespace Cards.Domain.Entity
{
    public class Card:EntityBase
    {
        
        public string? CardName { get; set; }
       
        public CardTypes CardType { get; set; }

        public string? CardNumber { get; set; }

        public string? CardDescription { get; set; }

        public DateTime CardExpieryDate { get; set; }

        public DateTime CardStatementDate { get; set; }

        public DateTime CardDueDate { get; set; }


        public DateTime CardNextStatementDate { get; set; }

        public int GracePeriod { get; set; }

        
        public double CardCurrentMonthExpenditure { get; set; }

        
        public double CardNextMonthExpenditure { get; set; }
        
        
        public double CardTotalExpenditure { get; set; }


        public List<string>? CardTransactions { get; set; }

        
    }
}
