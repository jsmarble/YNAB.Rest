using System.Collections.Generic;

namespace YNAB.Rest {
    public class ScheduledTransaction {
        public string id { get; set; }
        public string dateFirst { get; set; }
        public string dateNext { get; set; }
        public Frequency Frequency { get; set; }
        public long Amount { get; set; }
        public string Memo { get; set; }
        public FlagColor FlagColor { get; set; }
        public string AccountId { get; set; }
        public string PayeeId { get; set; }
        public string CategoryId { get; set; }
        public string TransferAccountId { get; set; }
        public bool Deleted { get; set; }
        public IList<SubTransaction> SubTransactions { get; set; }
    }

    public enum Frequency {
        Never,
        Daily,
        Weekly,
        EveryOtherWeek,
        TwiceAMonth,
        Every4Weeks,
        Monthly,
        EveryOtherMonth,
        Every3Months,
        Every4Months,
        TwiceAYear,
        Yearly,
        EveryOtherYear
    }
}
