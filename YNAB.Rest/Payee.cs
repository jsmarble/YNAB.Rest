using System;

namespace YNAB.Rest
{
    public class Payee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TransferAccountId { get; set; }
        public bool Delete { get; set; }
    }

    /*
{
 "data": {
   "payees": [
     {
       "id": "string",
       "name": "string",
       "transfer_account_id": "string",
       "deleted": true
     }
   ]
 }
}
    */
}