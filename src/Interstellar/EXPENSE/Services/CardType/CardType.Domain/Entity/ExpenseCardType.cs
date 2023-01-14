using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardType.Domain.Common;

namespace CardType.Domain.Entity;

public class ExpenseCardType:EntityBase
{
    public string  Name { get; set; }

    public string Description { get; set; }

    
}
