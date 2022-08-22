﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Common;
using Cards.Domain.Enums;

namespace Cards.Domain.Entity
{
    public class Card:EntityBase
    {
        public Guid CardId { get; set; }
        
        public string? CardName { get; set; }
       
        public CardTypes CardType { get; set; }

        public string? CardNumber { get; set; }

        public string? CardDescription { get; set; }

        public DateTime CardExpieryDate { get; set; }

        public DateTime CardStatementDate { get; set; }

        public static implicit operator Card(Card v)
        {
            throw new NotImplementedException();
        }
    }
}