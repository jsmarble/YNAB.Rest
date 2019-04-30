using System;
using System.Collections.Generic;
using System.Text;

namespace YNAB.Rest
{
    public class CategoryGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Hidden { get; set; }
        public bool Deleted { get; set; }
        public List<Category> Categories { get; set; }
    }
}
