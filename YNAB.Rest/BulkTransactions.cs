using System.Collections.Generic;

namespace YNAB.Rest
{
    public class BulkTransactions
    {
        public IList<string> TransactionIds { get; set; }
        public IList<string> DuplicateImportIds { get; set; }
    }

    /*
{
      "transaction_ids": [
        "string"
      ],
      "duplicate_import_ids": [
        "string"
      ]
    }
     */
}