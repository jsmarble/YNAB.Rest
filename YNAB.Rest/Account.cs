using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YNAB.Rest
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountType Type { get; set; }
        public bool OnBudget { get; set; }
        public bool Closed { get; set; }
        public int Balance { get; set; }
        public int ClearedBalance { get; set; }
        public int UnclearedBalance { get; set; }
        public bool Deleted { get; set; }
        public string Note { get; set; }

        /* JSON
{
  "data": {
    "account": {
      "id": "string",
      "name": "string",
      "type": "checking",
      "on_budget": true,
      "closed": true,
      "note": "string|null",
      "balance": 0,
      "cleared_balance": 0,
      "uncleared_balance": 0,
      "deleted": true
    }
  }
}
         */
    }
}