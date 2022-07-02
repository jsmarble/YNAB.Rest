using System.Collections.Generic;

namespace YNAB.Rest
{
    public class CategoriesData
    {
//        public IList<Category> Categories { get; set; }
        public IList<CategoryGroup> CategoryGroups { get; set; }
        public int ServerKnowledge { get; set; }
    }
}
