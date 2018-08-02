using System.Collections.Generic;

namespace YNAB.Rest
{
    public class PostBulkTransactions
    {
        public IList<Transaction> Transactions { get; set; }
    }
}