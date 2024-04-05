using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YNAB.Rest
{
    public enum GoalType
    {
        TB,
        TBD,
        MF,
        NEED,
        DEBT
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryGroupId { get; set; }
        public string CategoryGroupName { get; set; }
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
        public int? GoalDay { get; set; }
        public int? GoalCadence { get; set; }
        public int? GoalCadenceFrequency { get; set; }
        public int? GoalMonthsToBudget { get; set; }
        public int? GoalUnderFunded { get; set; }
        public int? GoalOverallFunded { get; set; }
        public int? GoalOverallLeft { get; set; }
        public int? GoalTarget { get; set; }
        public string GoalTargetMonth { get; set; }
        /* JSON
{
  "data": {
    "category": {
      "id": "string",
      "category_group_id": "string",
      "category_group_name": "string",
      "name": "string",
      "hidden": true,
      "original_category_group_id": "string|null",
      "note": "string|null",
      "budgeted": 0,
      "activity": 0,
      "balance": 0,
      "goal_type": "TB",
      "goal_day": 0,
      "goal_cadence": 0,
      "goal_cadence_frequency": 0,
      "goal_creation_month": "string|null",
      "goal_target": "integer|null",
      "goal_target_month": "string|null",
      "goal_percentage_complete": "integer|null",
      "goal_months_to_budget": 0,
      "goal_under_funded": 0,
      "goal_overall_funded": 0,
      "goal_overall_left": 0,
      "deleted": true
    }
  }
}
         */
    }
}
