using System.Collections.Generic;

namespace YNAB.Rest {
    public class ScheduledTransactionsData {
        public IList<ScheduledTransaction> ScheduledTransactions { get; set; }
        public long ServerKnowledge { get; set; }
    }
}
