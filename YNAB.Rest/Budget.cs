using Newtonsoft.Json;
using System;

namespace YNAB.Rest
{
    public class Budget
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedOn { get; set; }

        /* JSON
{
  "data": {
    "budget": {
      "id": "string",
      "name": "string",
      "last_modified_on": "string|null",
      "date_format": {
        "format": "string"
      },
      "currency_format": {
        "iso_code": "string",
        "example_format": "string",
        "decimal_digits": 0,
        "decimal_separator": "string",
        "symbol_first": true,
        "group_separator": "string",
        "currency_symbol": "string",
        "display_symbol": true
      },
      "accounts": [
        {
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
      ],
      "payees": [
        {
          "id": "string",
          "name": "string",
          "transfer_account_id": "string|null",
          "deleted": true
        }
      ],
      "payee_locations": [
        {
          "id": "string",
          "payee_id": "string",
          "latitude": "string|null",
          "longitude": "string|null",
          "deleted": true
        }
      ],
      "category_groups": [
        {
          "id": "string",
          "name": "string",
          "hidden": true,
          "deleted": true
        }
      ],
      "categories": [
        {
          "id": "string",
          "category_group_id": "string",
          "name": "string",
          "hidden": true,
          "original_category_group_id": "string|null",
          "note": "string|null",
          "budgeted": 0,
          "activity": 0,
          "balance": 0,
          "goal_type": "TB",
          "goal_creation_month": "string|null",
          "goal_target": "integer|null",
          "goal_target_month": "string|null",
          "goal_percentage_complete": "integer|null",
          "deleted": true
        }
      ],
      "months": [
        {
          "month": "string",
          "note": "string|null",
          "income": "integer|null",
          "budgeted": "integer|null",
          "activity": "integer|null",
          "to_be_budgeted": "integer|null",
          "age_of_money": "integer|null",
          "categories": [
            {
              "id": "string",
              "category_group_id": "string",
              "name": "string",
              "hidden": true,
              "original_category_group_id": "string|null",
              "note": "string|null",
              "budgeted": 0,
              "activity": 0,
              "balance": 0,
              "goal_type": "TB",
              "goal_creation_month": "string|null",
              "goal_target": "integer|null",
              "goal_target_month": "string|null",
              "goal_percentage_complete": "integer|null",
              "deleted": true
            }
          ]
        }
      ],
      "transactions": [
        {
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
          "deleted": true
        }
      ],
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
      ],
      "scheduled_transactions": [
        {
          "id": "string",
          "date_first": "string",
          "date_next": "string",
          "frequency": "never",
          "amount": 0,
          "memo": "string|null",
          "flag_color": "red",
          "account_id": "string",
          "payee_id": "string|null",
          "category_id": "string|null",
          "transfer_account_id": "string|null",
          "deleted": true
        }
      ],
      "scheduled_subtransactions": [
        {
          "id": "string",
          "scheduled_transaction_id": "string",
          "amount": 0,
          "memo": "string|null",
          "payee_id": "string|null",
          "category_id": "string|null",
          "transfer_account_id": "string|null",
          "deleted": true
        }
      ]
    },
    "server_knowledge": 0
  }
}
*/
    }
}