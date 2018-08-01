namespace YNAB.Rest
{
    public class SubTransaction
    {
        public string Id { get; set; }
        public string TransactionId { get; set; }
        public int Amount { get; set; }
        public string Memo { get; set; }
        public string PayeeId { get; set; }
        public string CategoryId { get; set; }
        public string TransferAccountId { get; set; }
        public bool Deleted { get; set; }

        /* JSON
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
         */
    }
}