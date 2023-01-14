using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Domain.Common;

namespace CardType.Domain.Entity;

public class ExpenseCardType:EntityBase
{
    string  Name { get; set; }

    string Description { get; set; }

    
}
