using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace CardType.Application.Features.CardType.Commands.CreateCardType
{
    public class CreateCardTypeCommand: IRequest<string>
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
