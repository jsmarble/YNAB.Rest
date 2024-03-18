using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace YNAB.Rest {
    public class ScheduledTransaction {
        public string Id { get; set; }
        public string DateFirst { get; set; }
        public string DateNext { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Frequency Frequency { get; set; }
        public long Amount { get; set; }
        public string Memo { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FlagColor? FlagColor { get; set; }
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
