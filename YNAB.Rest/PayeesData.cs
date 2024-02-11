using System;
using System.Collections.Generic;
using System.Text;

namespace YNAB.Rest
{
    public class PayeesData
    {
        public IList<Payee> Payees { get; set; }
        public long ServerKnowledge { get; set; }
    }
}
