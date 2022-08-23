﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Enums;

namespace Cards.Application.Features.Cards.Queries.GetCards
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
    }
}
