using System;
using System.Collections.Generic;

namespace YNAB.Rest
{
    public class AccountsData
    {
        public IList<Account> Accounts { get; set; }
        public long ServerKnowledge { get; set; }
    }
}
