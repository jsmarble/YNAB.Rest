using System.Collections.Generic;

namespace YNAB.Rest
{
    public class CategoriesData
    {
        public IList<CategoryGroup> CategoryGroups { get; set; }
        public int ServerKnowledge { get; set; }
    }
}
