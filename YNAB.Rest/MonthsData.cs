using System;
using System.Collections.Generic;

namespace YNAB.Rest {
    public class MonthsData {
        public IList<Month> Months { get; set; }
        public long ServerKnowldege { get; set; }
    }
}
