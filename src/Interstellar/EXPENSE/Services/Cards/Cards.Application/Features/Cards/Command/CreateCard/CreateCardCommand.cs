using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cards.Domain.Enums;

using MediatR;

namespace Cards.Application.Features.Cards.Command.CreateCard
{
    public class CreateCardCommand : IRequest<string>
    {

        public string? CardName { get; set; }

        public string? CardType { get; set; }

        public string? CardNumber { get; set; }

        public string? CardDescription { get; set; }

        public DateTime CardExpieryDate { get; set; }

        public DateTime CardStatementDate { get; set; }

        public int GracePeriod { get; set; }
    }
}
