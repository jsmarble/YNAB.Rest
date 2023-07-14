using System.Collections.Generic;

namespace YNAB.Rest
{
    public class ImportTransactions
    {
        public IList<string> TransactionIds { get; set; }
    }

    /*
    {
      "transaction_ids": [
        "string"
      
    }
    */
}
