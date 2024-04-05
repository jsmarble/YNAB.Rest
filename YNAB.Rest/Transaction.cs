using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace YNAB.Rest
{
    public enum ClearedStatus
    {
        Uncleared,
        Cleared,
        Reconciled
    }

    public enum FlagColor
    {
        Red, Orange, Yellow, Green, Blue, Purple
    }

    public enum DebtTransactionType
    {
        Payment, Refund, Fee, Interest, Escrow, BalanceAdjustment, Credit, Charge
    }

    public class Transaction
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Memo { get; set; }
        public int Amount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ClearedStatus Cleared { get; set; }
        public bool Approved { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FlagColor? FlagColor { get; set; }
        public string FlagName { get; set; }
        public string AccountId { get; set; }
        public string PayeeId { get; set; }
        public string CategoryId { get; set; }
        public string TransferAccountId { get; set; }
        public string ImportId { get; set; }
        public bool Deleted { get; set; }
        public string AccountName { get; set; }
        public string PayeeName { get; set; }
        public string CategoryName { get; set; }
        [JsonProperty(PropertyName = "subtransactions")]
        public IList<SubTransaction> SubTransactions { get; set; }
        public string MatchedTransactionId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DebtTransactionType? DebtTransactionType { get; set; }

        /*
{
  "data": {
    "transaction": {
      "id": "string",
      "date": "string",
      "amount": 0,
      "memo": "string|null",
      "cleared": "cleared",
      "approved": true,
      "flag_color": "red",
      "account_id": "string",
      "payee_id": "string|null",
      "category_id": "string|null",
      "transfer_account_id": "string|null",
      "import_id": "string|null",
      "deleted": true,
      "account_name": "string",
      "payee_name": "string|null",
      "category_name": "string|null",
      "subtransactions": [
        {
          "id": "string",
          "transaction_id": "string",
          "amount": 0,
          "memo": "string|null",
          "payee_id": "string|null",
          "category_id": "string|null",
          "transfer_account_id": "string|null",
          "deleted": true
        }
      ]
    }
  }
}
         */
    }
}