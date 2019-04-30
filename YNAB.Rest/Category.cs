using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YNAB.Rest
{
    public enum GoalType
    {
        TB,
        TBD,
        MF
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryGroupId { get; set; }
        public bool Hidden { get; set; }
        public string OriginalCategoryGroupId { get; set; }
        public string Note { get; set; }
        public int Budgeted { get; set; }
        public int Activity { get; set; }
        public int Balance { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public GoalType? GoalType { get; set; }
        public int? GoalPercentageComplete { get; set; }
        public bool Deleted { get; set; }

        /* JSON
{
  "data": {
    "category": {
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
  }
}
         */
    }
}
