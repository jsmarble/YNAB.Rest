namespace YNAB.Rest {
    public class Month {
        public string Month { get; set; }
        public string Note { get; set; }
        public long Income { get; set; }
        public long Budgeted { get; set; }
        public long Activity { get; set; }
        public long ToBeBudgeted { get; set; }
        public int AgeOfMoney { get; set; }
        public bool Deleted { get; set; }
        public IList<Category> Categories { get; set; }
    }

    /*
    {
      "data": {
        "month": {
          "month": "string",
          "note": "string",
          "income": 0,
          "budgeted": 0,
          "activity": 0,
          "to_be_budgeted": 0,
          "age_of_money": 0,
          "deleted": true,
          "categories": [
            {
              "id": "string",
              "category_group_id": "string",
              "name": "string",
              "hidden": true,
              "original_category_group_id": "string",
              "note": "string",
              "budgeted": 0,
              "activity": 0,
              "balance": 0,
              "goal_type": "TB",
              "goal_creation_month": "string",
              "goal_target": 0,
              "goal_target_month": "string",
              "goal_percentage_complete": 0,
              "deleted": true
            }
          ]
        }
      }
    }
    */
}
