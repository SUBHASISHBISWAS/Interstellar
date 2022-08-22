using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Cards.Application.Features.Cards.Command.DeleteCard
{
    public class DeleteCardCommand : IRequest
    {
        public Guid CardId { get; set; }
    }
}
